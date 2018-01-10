using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// Struct That Contains If The User Join/Left
    /// The User
    /// Message Of The User Status
    /// </summary>
    [Serializable]
    public class UserStatus
    {
        public User User { get; private set; }
        public bool Join { get; private set; }
        public Message Message { get; private set; }

        public UserStatus(User u, bool join, string status)
        {
            User = u;
            Join = join;
            Message = new Message(string.Format("{0} {1}", u, status));
        }
    }
}
