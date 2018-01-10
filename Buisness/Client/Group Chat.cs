using ChatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat
{
    /// <summary>
    /// Group Chat Object
    /// </summary>
    public class GroupChat : PrivateChat
    {
        internal event Action<User> InviteToGroup;
        internal event Action<User> KickFromGroup;

        /// <summary>
        /// Happens When User Join/Left The Group
        /// </summary>
        public event Action<User, bool> OnUserUpdateState;

        public GroupChat(string name) : base(name) { }

        /// <summary>
        /// Kick User From Chat
        /// </summary>
        /// <param name="u"></param>
        public void Kick(User u)
        {
            KickFromGroup(u);
        }

        /// <summary>
        /// Invite User To Chat
        /// </summary>
        /// <param name="u"></param>
        public void Invite(User u)
        {
            InviteToGroup(u);
        }

        /// <summary>
        /// Calls The OnUserUpdateState
        /// </summary>
        /// <param name="u"></param>
        /// <param name="b"></param>
        internal void UserUpdateState(User u, bool b)
        {
            OnUserUpdateState(u, b);
        }
    }
}
