using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
namespace Connection
{
    /// <summary>
    /// Object The Connection Serialize
    /// </summary>
    /// <typeparam name="S">The Enum</typeparam>
    [Serializable]
    public class SerializableObject<S>  where S : struct
    {
        public S Status { get; private set; }
        public object Item { get; private set; }
        internal bool Switch { get; private set; }

        public SerializableObject(S status, object item)
        {
            Status = status;
            Item = item;
        }

        public SerializableObject(S status) : this(status, null) { }

        internal SerializableObject()
        {
            Switch = true;
        }
    }
}
