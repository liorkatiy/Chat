using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Connection
{
    /// <summary>
    /// IConnect Interface Object That Can Use Connection
    /// </summary>
    /// <typeparam name="S">The Enum</typeparam>
    public interface IConnect<S> where S : struct
    {
        Connection<S> Connection { get; set; }
    }
}