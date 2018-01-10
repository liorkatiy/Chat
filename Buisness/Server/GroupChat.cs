using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatData;
using Connection;

namespace ServerChat
{
    /// <summary>
    /// Group Chat Object
    /// </summary>
    class GroupChat : UsersHandler, IHaveID<Guid>
    {
        /// <summary>
        /// The Group ID
        /// </summary>
        public Guid ID { get; private set; }
        /// <summary>
        /// The Group Name
        /// </summary>
        public string Name { get; private set; }

        NetUser Admin;

        public GroupChat(NetUser admin, string name)
        {
            Admin = admin;
            Name = name;
            ID = Guid.NewGuid();
            AddStatus = string.Format("Join {0}", name);
            RemoveStatus = string.Format("Left {0}", name);
            KickStatus = string.Format("Kicked From {0}", name);
        }

        /// <summary>
        /// Check If The User Is The Group Admin
        /// </summary>
        /// <param name="u">The User To Verify</param>
        /// <returns></returns>
        public bool IsAdmin(NetUser u)
        {
            return u == Admin;
        }

        //Override Of The UserStatusChanged
        protected override void UserStatusChanged(bool join, string status, User u)
        {
            GroupUserStatus groupStatus = new GroupUserStatus(ID, u, join, status);
            SendToAll(new SerializableObject<Status>(Status.GroupUserStatus, groupStatus));
        }
    }
}
