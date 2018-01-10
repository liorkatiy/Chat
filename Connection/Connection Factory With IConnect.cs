using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Use To Create New Connections
    /// </summary>
    /// <typeparam name="S">The Enum</typeparam>
    /// <typeparam name="IConnect">The IConnect Object</typeparam>
    public sealed class ConnectionFactory<S,IConnect> : BaseConnectionFactory<S> where S : struct where IConnect : IConnect<S>
    {
        /// <summary>
        /// Add Status Action
        /// </summary>
        /// <typeparam name="O">Generic Parameter</typeparam>
        /// <param name="status">The Enum</param>
        /// <param name="action">Action That Take IConnect And Generic Object As Parameters</param>
        public void Add<O>(S status, Action<IConnect, O> action)
        {
            Add(status, (o, c) => action((Connection<S,IConnect>)c, (O)o));
        }

        /// <summary>
        /// Add Status Action
        /// </summary>
        /// <param name="status">The Enum</param>
        /// <param name="action">Action That Take IConnect As Parameter</param>
        public void Add(S status, Action<IConnect> action)
        {
            Add(status, (o, c) => action((Connection<S, IConnect>)c));
        }

        /// <summary>
        /// Set The IConnet Connection
        /// </summary>
        /// <param name="stream">The Network Stream</param>
        /// <param name="IConnect">The Iconnet Object</param>
        /// <param name="name">Connection Name</param>
        public void CreateConnection(NetworkStream stream, IConnect IConnect,string name)
        {
            Connection<S, IConnect> con = new Connection<S, IConnect>(stream, IConnect,name);
            InitializeConnection(con);
            IConnect.Connection = con;
        }

        /// <summary>
        /// Set The IConnet Connection From Another Connection
        /// Will Stop The Other Connection And Call OnChangeStatus Event On The Other Side
        /// </summary>
        /// <typeparam name="S1">The Enum</typeparam>
        /// <param name="con">Old Connection</param>
        /// <param name="IConnect">IConnect Object</param>
        /// <param name="name">Connection Name</param>
        public void CreateConnection<S1>(Connection<S1> con, IConnect IConnect,string name) where S1 : struct
        {
            con.Stop();
            con.Send(new SerializableObject<S1>());
            CreateConnection(con.BaseStream, IConnect,name);
        }
    }
}
