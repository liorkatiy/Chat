using ChatData;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using DAL;
using System.Collections.Generic;
using Mail;
using System.Data;
using Connection;

namespace ServerChat
{
    /// <summary>
    /// Main Server Class
    /// </summary>
    public class Server
    {
        bool Active;

        TcpListener listner;
        ServerUsers MyUsers;
        ConnectedData database;

        EntryHandler Entry;
        PrivateChatsHandler Private;
        GroupChatHandler Group;
        IDHandler ID;

        ConnectionFactory<Status, NetUser> chatStatusFactory;

        #region Events
        /// <summary>
        /// Happens When New Client Join The Chat
        /// </summary>
        public event Action<NetUser> OnClientJoin;

        /// <summary>
        /// Happens When Client Leaving The Chat
        /// </summary>
        public event Action<NetUser> OnClientLeft;

        /// <summary>
        /// Happens When Message Is Sent To World Chat
        /// </summary>
        public event Action<Message> OnNewMessage;

        #endregion

        /// <summary>
        /// Instantiate Server Object With Email Verification
        /// </summary>
        /// <param name="amountOfUsers">The Server Amount Of Users</param>
        /// <param name="smtp">The Email Smtp</param>
        /// <param name="port">The Email Port</param>
        /// <param name="ssl">The Email SSL</param>
        /// <param name="username">The Email Address</param>
        /// <param name="password">The Email Password</param>
        /// <param name="connectionString">Data Connection String</param>
        public Server(int amountOfUsers,string connectionString, string smtp, int port, bool ssl, string username, string password)
        {
            InitializeServer(amountOfUsers, connectionString);
            MailInfo mailInfo = new MailInfo(smtp, port, ssl, username, password);
            Entry = new EntryHandler(database, MyUsers, mailInfo, OnLoginSuccess);
        }

        /// <summary>
        /// Instantiate Server Object Without Email Verification
        /// </summary>
        /// <param name="amountofusers">The Server Amount Of Users</param>
        /// <param name="connectionString">Data Connection String</param>
        public Server(int amountofusers,string connectionString)
        {
            InitializeServer(amountofusers, connectionString);
            Entry = new EntryHandler(MyUsers, database, OnLoginSuccess);
        }

        //Initialize The Server Fields
        void InitializeServer(int amountofusers, string connectionString)
        {
            database = new ConnectedData(connectionString);  
            MyUsers = new ServerUsers(amountofusers);
            MyUsers.OnUserAdded += OnUserJoin;
            MyUsers.OnUserRemoved += OnUserLeft;
            ID = new IDHandler(amountofusers);
            Private = new PrivateChatsHandler(MyUsers, database);
            Group = new GroupChatHandler(MyUsers, database);
            InitializeFactory();
        }

        //Building The Factory For The Status Connection
        void InitializeFactory()
        {
            chatStatusFactory = new ConnectionFactory<Status, NetUser>();
            chatStatusFactory.Add<Message>(Status.Message, SendMessageTo);
            chatStatusFactory.Add(Status.Exit, (u) => u.Dispose());
            chatStatusFactory.Add<User>(Status.PrivateStart, Private.Start);
            chatStatusFactory.Add<User>(Status.PrivateClose, Private.Close);
            chatStatusFactory.Add<string>(Status.GroupStart,Group.Start);
            chatStatusFactory.Add<Guid>(Status.GroupLeave, Group.Leave);
            chatStatusFactory.Add<GroupUser>(Status.GroupInvite, Group.Invite);
            chatStatusFactory.Add<GroupUser>(Status.GroupKick, Group.Kick);
        }

        /// <summary>
        /// Start The Server
        /// </summary>
        /// <param name="s"></param>
        public bool Start(System.Net.IPEndPoint ip,out string ErrorMsg)
        {
            ErrorMsg = string.Empty;
            if (database.IsConnectionStringValid())
            {
                Active = true;
                database.ResetAllUsers();
                try
                {
                    listner = new TcpListener(ip);
                    listner.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Server || Start |" + e.Message);
                    ErrorMsg = "Couldn't Start A Lister With Given IP";
                    return false;
                }
                new Thread(StartRecivingClients).Start();
                return true;
            }
            ErrorMsg = "Couldn't Connect To The DataBase";
            return false;
        }

        // Listen To New Clients Until Server Is Closed
        void StartRecivingClients()
        {
            while (Active)
            {
                try
                {
                    TcpClient c = listner.AcceptTcpClient();
                    Entry.Start(c.GetStream());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Server || StartRecivingClients |" + e.Message);
                }
            }
        }

        /// <summary>
        /// Closes The Server
        /// </summary>
        public void Close()
        {
            Active = false;
            if (listner != null)
                listner.Stop();
            database.Dispose();
            MyUsers.Close();
        }

        /// <summary>
        /// Send Message To Global Chat
        /// </summary>
        /// <param name="txt">Message</param>
        public void SendMessageToAllUsers(string txt)
        {
            Message msg = new Message(txt);
            OnNewMessage(msg);
            MyUsers.SendMessage(msg);
        }

        /// <summary>
        /// Kick User
        /// </summary>
        /// <param name="id">User ID</param>
        public void Kick(int id)
        {
            MyUsers.KickByID(id);
        }

        #region Server Events

        //Happens When User Is Added To MyUsers
        void OnUserJoin(NetUser u)
        {
            database.UserLogin(u.Email, u.Name,u.ID);
            OnClientJoin?.Invoke(u);
        }

        //Happens When User Is Removed From MyUsers
        void OnUserLeft(NetUser u)
        {
            ID.TakeID(u);
            database.UserLogOut(u.Email);
            if (Active)
                OnClientLeft?.Invoke(u);
        }

        //Happens When Login Success
        void OnLoginSuccess(Connection<Entry> con, LoginInfo loginInfo)
        {
            NetUser netUser = new NetUser(loginInfo, ID.GiveID());
            chatStatusFactory.CreateConnection(con, netUser, "Server Chat: " + netUser.Name);
            netUser.Connection.Start();
            netUser.Connection.OnClose += () => MyUsers.Remove(netUser);
            MyUsers.Add(netUser);
        }

        //Happens When User Send Message
        void SendMessageTo(NetUser u, Message msg)
        {
            switch (msg.Type)
            {
                case MessageType.Global:
                    database.AddMessage(msg, u.Email);
                    OnNewMessage(msg);
                    MyUsers.SendMessage(msg);
                    break;
                case MessageType.Private:
                    Private.SendMessage(u, (Message<int>)msg);
                    break;
                case MessageType.Group:
                    Group.SendMesseage(u, (Message<Guid>)msg);
                    break;
            }
        }

        #endregion
    }
}
