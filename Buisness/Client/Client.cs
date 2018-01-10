using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatData;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using Mail;
using Connection;

namespace ClientChat
{
    /// <summary>
    /// Main Client Class
    /// </summary>
    public class Client
    {
        NetworkStream stream;
        MessageInfo MessageInfo;
        IPEndPoint HostIP;
        ConnectionFactory<Entry> EntryFactory;
        ConnectionFactory<Status> StatusFactory;
        Connection<Status> StatusCon;
        PrivateChatHandler PrivateChat;
        GroupChatHandler GroupChat;

        #region Events
        /// <summary>
        /// Event Happens When Had Problem With The Server
        /// </summary>
        public event Action<Error> OnError;

        /// <summary>
        /// Get GroupChat Instance 
        /// And The List Of All The Users In The Group
        /// </summary>
        public event Action<GroupChat, User[]> OnStartGroupChat;

        /// <summary>
        /// Get PrivateChat Instance
        /// </summary>
        public event Action<PrivateChat> OnStartPrivateChat;

        /// <summary>
        /// Happens When Login Success 
        /// </summary>
        public event Action<User[]> OnInitializeUserList;

        /// <summary>
        /// Happens When User Join/Leave Chat
        /// </summary>
        public event Action<User,bool> OnUpdateUserList;

        /// <summary>
        /// Happens When New Message Send To Global Chat
        /// </summary>
        public event Action<Message> OnGetMessage;

        /// <summary>
        /// When User Try To Register True If Mail Verification Needed False Otherwise
        /// </summary>
        public event Action<bool> OnRegister;
        #endregion

        public Client(IPEndPoint HostIP, MessageInfo msgInfo) : this(HostIP)
        {
            MessageInfo = msgInfo;
            PrivateChat = new PrivateChatHandler(msgInfo);
            GroupChat = new GroupChatHandler(msgInfo);
            StatusFactory = new ConnectionFactory<Status>();
            StatusFactory.Add<Message>(Status.Message, GetMessage);
            StatusFactory.Add<UserStatus>(Status.UserStatus, GetUserStatus);
            StatusFactory.Add<Error>(Status.ServerError, Error);
            StatusFactory.Add<GroupUserStatus>(Status.GroupUserStatus, GroupChat.UserStatus);
            StatusFactory.Add<Guid>(Status.GroupKick, GroupChat.Close);
            StatusFactory.Add<User>(Status.PrivateStart, (o) => OnStartPrivateChat(PrivateChat.Get(o)));
            StatusFactory.Add<User>(Status.PrivateClose, PrivateChat.Close);
            StatusFactory.Add<NewGroup>(Status.GroupStart, StartGroupChat);
        }

        public Client(IPEndPoint HostIP)
        {
            EntryFactory = new ConnectionFactory<Entry>();
            this.HostIP = HostIP;
            EntryFactory.Add<VerifyClientLogin>(Entry.Login, LoginRecive);
            EntryFactory.Add<VerifyClientRegister>(Entry.Register, RegisterRecive);
        }

        /// <summary>
        /// Login To The Server
        /// </summary>
        /// <param name="loginInfo">Login Info</param>
        public void Login(LoginInfo loginInfo)
        {
            if (!TryConnecting())
                return;
            Connection<Entry> entryConnection = EntryFactory.CreateConnection(stream,"Client Login");
            entryConnection.OnChangeStatus += OnChangeStatus;
            entryConnection.Start();
            entryConnection.Send(Entry.Login, loginInfo);
        }

        /// <summary>
        /// Register To The Server
        /// </summary>
        /// <param name="registerInfo">Registeration Info</param>
        public void Register(RegisterInfo registerInfo)
        {
            if (!TryConnecting())
                return;
            Connection<Entry> e = EntryFactory.CreateConnection(stream,"Client Register");
            e.Start();
            e.Send(Entry.Register, registerInfo);
        }

        //try to connect to the server
        bool TryConnecting()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(HostIP);
                stream = client.GetStream();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Client || ClientToServer " + e.Message);
                OnError?.Invoke(new Error("Cant Connect To Server", true));
                return false;
            }
        }

        /// <summary>
        /// Send The Code The Client Got Via Mail 
        /// </summary>
        /// <param name="Code">The Code</param>
        /// <returns></returns>
        public bool SendCode(int Code)
        {
            CodeVerify result = CodeSender.Send(Code, stream);
            switch (result)
            {
                case CodeVerify.Success:
                    Close();
                    return true;
                case CodeVerify.TryAgain:
                    Error(new Error("Wrong Code Try Again", false));
                    break;
                case CodeVerify.TimeOut:
                    Error(new Error("Time Out", true));
                    break;
                case CodeVerify.Fail:
                    Error(new Error("Failed To Many Times", true));
                    break;
            }
            return false;
        }

        /// <summary>
        /// Send Message To Global Chat
        /// </summary>
        /// <param name="txt">Message Text</param>
        public void SendMessage(string txt)
        {
            StatusCon.Send(Status.Message, new Message(MessageInfo, txt));
        }

        /// <summary>
        /// Start Private Chat
        /// </summary>
        /// <param name="recipient">User To Start Chat With</param>
        public void StartPrivateChat(User recipient)
        {
            PrivateChat chat = PrivateChat.Start(recipient);
            OnStartPrivateChat(chat);
        }

        /// <summary>
        /// Ask The Server To Start New Group
        /// </summary>
        /// <param name="name">Group Name</param>
        public void StartGroupChat(string name)
        {
            GroupChat.Start(name);
        }

        /// <summary>
        /// Close Connection With Server
        /// </summary>
        public void Close()
        {
            if (StatusCon != null && StatusCon.Send(Status.Exit))
            {
                StatusCon.Close();
            }
        }

        #region Entry Connection Events

        ///Get Called When The Server Send Entry.Register
        void RegisterRecive(Connection<Entry> con, VerifyClientRegister verify)
        {
            if (!verify)
            {
                Error(new Error(verify, true));
            }
            else
            {
                OnRegister(verify.MailVerificationNeeded);
            }
            con.Stop();
        }

        //Gets Called When The Server Send Entry.Login
        void LoginRecive(Connection<Entry> con, VerifyClientLogin verify)
        {
            if (verify)
            {
                User[] users = verify.Users;
                OnInitializeUserList?.Invoke(users);     
            }
            else
            {
                Error(new Error(verify, true));
                con.Stop();
            }
        }

        //Get Called When Logged In And Change The Connection<Entry> To Connection<Status>
        private void OnChangeStatus(NetworkStream stream)
        {
            StatusCon = StatusFactory.CreateConnection(stream, "Client Chat");
            PrivateChat.WriteToServer += StatusCon.Send;
            GroupChat.WriteToServer += StatusCon.Send;
            StatusCon.Start();
        }

        #endregion

        #region Status Connection Events

        //Gets Called When The Server Send Status.Message
        void GetMessage(Message msg)
        {
            switch (msg.Type)
            {
                case MessageType.Global:
                    OnGetMessage?.Invoke(msg);
                    break;
                case MessageType.Private:
                    PrivateChat.GetMessage((Message<int>)msg);
                    break;
                case MessageType.Group:
                    GroupChat.GetMessage((Message<Guid>)msg);
                    break;
            }
        }

        //Gets Called When The Server Send Status.UserStatus
        void GetUserStatus(UserStatus status)
        {
            OnUpdateUserList?.Invoke(status.User, status.Join);
            GetMessage(status.Message);
        }

        //Gets Called When The Server Had Problem
        void Error(Error error)
        {
            OnError?.Invoke(error);
        }

        //Gets Called When The Server Sent Status.GroupStart
        void StartGroupChat(NewGroup g)
        {
            OnStartGroupChat(GroupChat.Get(g), g.ToArray());
        }

        #endregion
    }
}