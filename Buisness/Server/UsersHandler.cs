using ChatData;
using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    /// <summary>
    ///  Base Class For Handling Users
    /// </summary>
    abstract class UsersHandler
    {
        #region Events
        /// <summary>
        /// Happens Before User Is Added
        /// </summary>
        public event Action<NetUser> OnUserAdded;
        /// <summary>
        /// Happens After User Is Removed
        /// </summary>
        public event Action<NetUser> OnUserRemoved;
        /// <summary>
        #endregion

        #region StatusStrings
        /// <summary>
        /// The Status When User Is Added
        /// </summary>
        protected string AddStatus { private get; set; }
        /// <summary>
        /// The Status When User Is Removed
        /// </summary>
        protected string RemoveStatus { private get; set; }
        /// <summary>
        /// The Status When User Is Kicked
        /// </summary>
        protected string KickStatus { private get; set; }
        #endregion

        protected ThreadSafeDict<int, NetUser> users;

        /// <summary>
        /// Instantiate New UserHandler
        /// </summary>
        public UsersHandler() : this(0) { }

        /// <summary>
        /// Instantiate New UserHandler With Starting Size
        /// </summary>
        public UsersHandler(int amount)
        {
            users = new ThreadSafeDict<int, NetUser>(amount);
        }

        /// <summary>
        /// Returns The Amount Of Users In The Dictionary
        /// </summary>
        public int Count { get { return users.Count; } }

        /// <summary>
        /// Return A NetUser From ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public NetUser this[int ID]
        {
            get
            {
                return users[ID];
            }
        }

        /// <summary>
        /// Add NetUser
        /// </summary>
        /// <param name="u"></param>
        public void Add(NetUser u)
        {
            OnUserAdded?.Invoke(u);
            try
            {
                UserStatusChanged(true, AddStatus, u);
                users.Add(u);
            }
            catch (Exception e)
            {
                Console.WriteLine("GroupChat|Add| User: " + u.Name + " \nError: " + e.Message);
            }
        }

        /// <summary>
        /// Remove NetUser
        /// </summary>
        /// <param name="u"></param>
        public void Remove(NetUser u)
        {
            Remove(u, RemoveStatus);
        }

        /// <summary>
        /// Kick NetUser
        /// </summary>
        /// <param name="u"></param>
        public void Kick(NetUser u)
        {
            Remove(u, KickStatus);
        }

        //Remove NetUser And Take Status String 
        void Remove(NetUser u, string status)
        {
            try
            {
                if (users.Remove(u))
                {
                    UserStatusChanged(false, status, u);
                    OnUserRemoved?.Invoke(u);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GroupChat|Remove| User: " + u.Name + " \nError: " + e.Message);
            }
        }

        /// <summary>
        /// This Get Called After User Is Removed And Before User Is Added
        /// </summary>
        /// <param name="join">True If The User Join False Otherwise</param>
        /// <param name="status">Status String Will Be Empty If Wasnt Assigned To</param>
        /// <param name="u">The User</param>
        protected abstract void UserStatusChanged(bool join, string status, User u);

        /// <summary>
        /// Get All The NetUsers As User[]
        /// </summary>
        internal User[] GetAllUsers
        {
            get
            {
                {
                    User[] list = new User[users.Count];
                    int i = 0;
                    foreach (NetUser netUser in users)
                    {
                        list[i++] = netUser;
                    }
                    return list;
                }
            }
        }

        /// <summary>
        /// Send To All The Users SerializableObject TypeOf Status
        /// </summary>
        /// <param name="serObj">The Object</param>
        protected void SendToAll(SerializableObject<Status> serObj)
        {
            foreach (NetUser u in users)
            {
                u.Send(serObj);
            }
        }

        /// <summary>
        /// Send Message To All The Users
        /// </summary>
        /// <param name="msg">The Message</param>
        public void SendMessage(Message msg)
        {
            SerializableObject<Status> obj =
                new SerializableObject<Status>(Status.Message, msg);
            SendToAll(obj);
        }
    }
}
