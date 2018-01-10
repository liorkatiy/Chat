using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Derived From Connection Uses IConnet Item
    /// </summary>
    /// <typeparam name="S">Enum</typeparam>
    /// <typeparam name="IConnect">Object That Implements IConnect</typeparam>
    class Connection<S, IConnect> : Connection<S>
        where S : struct
        where IConnect : IConnect<S>
    {
        IConnect IConnectItem;

        internal Connection(NetworkStream stream, IConnect extraInfo, string name) : base(stream, name)
        {
            IConnectItem = extraInfo;
        }

        //Can Implictly Cast This As IConnect
        public static implicit operator IConnect(Connection<S, IConnect> con)
        {
            return con.IConnectItem;
        }
    }
}
