using ChatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Connection;

namespace ServerChat
{
    /// <summary>
    /// Derived From Users Handler And Handles All The Users In The Server
    /// </summary>
    class ServerUsers : UsersHandler
    {
        int maxUsers;

        /// <summary>
        /// Instantiate New Server Users With Fixed Size
        /// </summary>
        /// <param name="MaxUsers"></param>
        public ServerUsers(int MaxUsers) : base(MaxUsers)
        {
            maxUsers = MaxUsers;
            AddStatus = "Connected";
            RemoveStatus = "Disconnected";
            KickStatus = "Got Kicked";
        }

        /// <summary>
        /// Check If The Amount Of Users Is Lower Than The Max Value
        /// </summary>
        public bool HaveRoom { get { { return maxUsers > users.Count; } } }

        //Override The Abstract UserStatusChanged
        protected override void UserStatusChanged(bool join, string status, User u)
        {
            UserStatus s = new UserStatus(u, join, status);
            SendToAll(new SerializableObject<Status>(Status.UserStatus, s));
        }

        /// <summary>
        /// Kick A User By ID
        /// </summary>
        /// <param name="ID"></param>
        public void KickByID(int ID)
        {
            NetUser u = users[ID];
            Kick(u);
            u.SendError("You Got Kicked", true);
            u.Dispose();
        }

        /// <summary>
        /// Send All The Users Critical Error And Close All Of The Connections
        /// </summary>
        public void Close()
        {
            Error error = new Error("Server Close", true);
            SerializableObject<Status> obj = new SerializableObject<Status>(Status.ServerError, error);
            foreach (NetUser u in users)
            {
                u.Send(obj);
                u.Connection.Close();
            }
        }

    }
}
