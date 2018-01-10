using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using ChatData;
using Mail;
using DAL;
using System.Net.Sockets;

namespace ServerChat
{
    /// <summary>
    /// Handles All The Users Entry Validation
    /// </summary>
    class EntryHandler 
    {
        EmailHandler mailhandler;
        bool mailVerificationNeeded;
        ConnectedData database;
        ServerUsers MyUsers;
        ConnectionFactory<Entry> entryFactory;

        // Happens When User Logged successfully
        event Action<Connection<Entry>, LoginInfo> OnLoginSuccess;

        /// <summary>
        /// Create Entry Handler Without Mail Register Verification
        /// </summary>
        /// <param name="myUsers">The Server Users</param>
        /// <param name="database">The DataBase</param>
        /// <param name="OnLoginSuccess">Happens When User Logged successfully</param>
        public EntryHandler(ServerUsers myUsers, ConnectedData database, Action<Connection<Entry>, LoginInfo> OnLoginSuccess)
        {
            this.OnLoginSuccess = OnLoginSuccess;
            this.database = database;
            MyUsers = myUsers;
            entryFactory = new ConnectionFactory<Entry>();
            entryFactory.Add<LoginInfo>(Entry.Login, Login);
            entryFactory.Add<RegisterInfo>(Entry.Register, Register);
        }

        /// <summary>
        /// Create Entry Handler With Mail Register Verification
        /// </summary>
        /// <param name="database">The DataBase</param>
        /// <param name="myUsers">The Server Users</param>
        /// <param name="mailInfo">The Mail Info</param>
        /// <param name="OnLoginSuccess">Happens When User Logged successfully</param>
        public EntryHandler(ConnectedData database, ServerUsers myUsers, MailInfo mailInfo, Action<Connection<Entry>, LoginInfo> OnLoginSuccess)
            : this(myUsers, database,OnLoginSuccess)
        {
            mailVerificationNeeded = true;
            mailhandler = new EmailHandler(mailInfo);
        }

        /// <summary>
        /// Create Entry Connection
        /// </summary>
        /// <param name="stream"></param>
        public void Start(NetworkStream stream)
        {
            entryFactory.CreateConnection(stream, "Server Entry").Start();
        }

        //Get Called If The Client Asked To Register
        void Register(Connection<Entry> con, RegisterInfo info)
        {
            if (database.ContainsUser(info.Email)) //check if the user isnt in the data base already
            {
                con.Send(Entry.Register, new VerifyClientRegister("Email Is Already Registered"));
            }
            else
            {
                if (!mailVerificationNeeded)
                {
                    con.Send(Entry.Register, new VerifyClientRegister(false));
                    database.AddUser(info);
                }
                else
                {
                    CodeVerification<int> verifycode;
                    if (!mailhandler.SendMail(info.Email, out verifycode))
                    {
                        con.Send(Entry.Register, new VerifyClientRegister("Couldn't Send Mail"));
                    }
                    else
                    {
                        con.Send(Entry.Register, new VerifyClientRegister(true));
                        if (verifycode.Verify(con.BaseStream, 75))
                        {
                            database.AddUser(info);
                        }
                    }
                }
            }
            con.Close();
        }

        //Gets Called If The Client Ask To Login
        void Login(Connection<Entry> con, LoginInfo loginInfo)
        {
            if (MyUsers.HaveRoom)
            {
                string error;
                if (database.VerifyUser(loginInfo,out error))
                {
                    con.Send(Entry.Login, new VerifyClientLogin(MyUsers.GetAllUsers));  //send the new user all the users that are connected
                    OnLoginSuccess(con, loginInfo);
                }
                else
                {
                    con.Send(Entry.Login, new VerifyClientLogin(error));
                    con.Close();
                }
            }
            else
            {
                con.Send(Entry.Login, new VerifyClientLogin("Server Is Full"));
                con.Close();
            }
        }

    }
}
