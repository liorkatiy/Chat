 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Used To Create New Connections
    /// </summary>
    /// <typeparam name="S">Enum</typeparam>
    public sealed class ConnectionFactory<S> : BaseConnectionFactory<S>
        where S : struct
    {
        /// <summary>
        /// Add New Status Action
        /// </summary>
        /// <param name="status">The Enum</param>
        /// <param name="action">Action That Take Connection As Parameter</param>
        public void Add(S status, Action<Connection<S>> action)
        {
            Add(status, (o, c) => action(c));
        }

        /// <summary>
        /// Add New Status Action
        /// </summary>
        /// <typeparam name="O">The Action Parameter</typeparam>
        /// <param name="status">The Enum</param>
        /// <param name="action">Action That Take Connection And A Generic Parameters</param>
        public void Add<O>(S status, Action<Connection<S>, O> action)
        {
            Add(status, (o, c) => action(c, (O)o));
        }

        /// <summary>
        /// Create Connection From Stream
        /// </summary>
        /// <param name="stream">The Network Stream</param>
        /// <param name="name">Connection name</param>
        /// <returns></returns>
        public Connection<S> CreateConnection(NetworkStream stream, string name)
        {
            Connection<S> con = new Connection<S>(stream, name);
            InitializeConnection(con);
            return con;
        }

        /// <summary>
        /// Create Connection From Another Connection
        /// Will Stop The Other Connection And Call OnChangeStatus Event On The Other Side
        /// </summary>
        /// <typeparam name="S1">Old Connection Enum</typeparam>
        /// <param name="con">The Connection To Stop</param>
        /// <param name="name">New Connection Name</param>
        /// <returns>New Connection</returns>
        public Connection<S> CreateConnection<S1>(Connection<S1> con, string name) where S1 : struct
        {
            con.Stop();
            con.Send(new SerializableObject<S1>());
            return CreateConnection(con.BaseStream, name);
        }
    }
}
