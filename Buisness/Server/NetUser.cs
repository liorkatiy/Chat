using ChatData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Connection;

namespace ServerChat
{
    /// <summary>
    /// Class For Every User In Chat
    /// </summary>
    public class NetUser : IHaveID<int>, IDisposable, IConnect<Status>
    {
        /// <summary>
        /// The User Connection
        /// </summary>
        public Connection<Status> Connection { get; set; }

        /// <summary>
        /// Dictionary Of All The Users This User Have Chats With
        /// </summary>
        internal ThreadSafeDict<int, NetUser> PrivateChats { get; set; }

        /// <summary>
        /// Dictionary Of All The GroupChats This User Is In 
        /// </summary>
        internal ThreadSafeDict<Guid, GroupChat> GroupChats { get; set; }

        /// <summary>
        /// This User ID ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// This User Email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// This User Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Create New NetUser
        /// </summary>
        /// <param name="loginData">Set Name And Email From Login Data</param>
        /// <param name="id">The User ID</param>
        internal NetUser(LoginInfo loginData, int id)
        {
            Email = loginData.Email;
            Name = loginData.Name;
            ID = id;
            PrivateChats = new ThreadSafeDict<int, NetUser>();
            GroupChats = new ThreadSafeDict<Guid, GroupChat>();
        }

        /// <summary>
        /// Send Object To The Client
        /// </summary>
        /// <param name="obj">Object To Send In The Connection</param>
        /// 
        internal void Send(SerializableObject<Status> obj)
        {
            Connection.Send(obj);
        }

        /// <summary>
        /// Send Server Error To This User
        /// </summary>
        /// <param name="msg">Error Message</param>
        /// <param name="isCritical">Is It Critical</param>
        internal void SendError(string msg, bool isCritical)
        {
            Error serverError = new Error(msg, isCritical);
            SerializableObject<Status> obj =
                new SerializableObject<Status>(Status.ServerError, serverError);
            Send(obj);
        }

        /// <summary>
        /// Closes The Connection And All The Group And Private Chats
        /// </summary>
        public void Dispose()
        {
            Connection.Close();
            foreach (NetUser recipient in PrivateChats)
            {
                recipient.Send(new SerializableObject<Status>(Status.PrivateClose, (User)this));
            }
            foreach (GroupChat group in GroupChats)
            {
                group.Remove(this);
            }
        }

        /// <summary>
        /// Can Implicitly Cast NetUser As User
        /// </summary>
        /// <param name="u"></param>
        public static implicit operator User(NetUser u)
        {
            return new User(u.Name, u.ID);
        }

        /// <summary>
        /// Can Implicitly Cast NetUser As Int Using The ID
        /// </summary>
        /// <param name="u"></param>
        public static implicit operator int(NetUser u)
        {
            return u.ID;
        }

        /// <summary>
        /// Override The Get HashCode To The Unique ID
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ID;
        }

        /// <summary>
        /// Override The Equals Check For Equaly By ID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            return ((NetUser)obj).ID == ID;
        }
    }
}