using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// Contains User And Group ID
    /// </summary>
    [Serializable]
    public struct GroupUser
    {
        public Guid ID { get; private set; }
        public User User { get; private set; }

        public GroupUser(Guid ID, User user)
        {
            this.ID = ID;
            User = user;
        }
    }

    /// <summary>
    /// User Status With Group ID
    /// </summary>
    [Serializable]
    public class GroupUserStatus : UserStatus
    {
        public Guid ID { get; private set; }

        public GroupUserStatus(Guid ID, User user, bool join, string status) : base(user, join, status)
        {
            this.ID = ID;
        }
    }

    /// <summary>
    /// New Group Struct With Group Name ,ID And Current Users
    /// </summary>
    [Serializable]
    public struct NewGroup : IEnumerable<User>
    {
        public string Name { get; private set; }
        public Guid ID { get; private set; }
        User[] UsersInGroup;

        public NewGroup(Guid ID, string name, User[] users)
        {
            this.ID = ID;
            Name = name;
            UsersInGroup = users;
        }
        public NewGroup(Guid ID, string name) : this(ID, name, null) { }

        public IEnumerator<User> GetEnumerator()
        {
            if (UsersInGroup != null)
            {
                for (int i = 0; i < UsersInGroup.Length; i++)
                {
                    yield return UsersInGroup[i];
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
