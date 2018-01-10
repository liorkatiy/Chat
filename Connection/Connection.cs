using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Connection Object To Get And Send Data Via NetworkStream
    /// </summary>
    /// <typeparam name="S">The Enum</typeparam>
    public class Connection<S> where S : struct
    {
        string name;
        bool active;
        bool stop;
        BinaryFormatter bf;
        protected Dictionary<S, Action<object,Connection<S>>> dict;

        /// <summary>
        /// The NetWorkStream The Connection Uses
        /// </summary>
        public NetworkStream BaseStream { get; private set; }

        #region Events
        /// <summary>
        /// Happens When The Connection Had Problem Or Wrong Enum
        /// </summary>
        public event Action OnError;

        /// <summary>
        /// Happens When The Connection Close But Not When Stopped
        /// </summary>
        public event Action OnClose;

        /// <summary>
        /// Happens When The Other Side Asked To Switch The Connection Enum
        /// </summary>
        public event Action<NetworkStream> OnChangeStatus;
        #endregion

        internal Connection(NetworkStream stream,string name)
        {
            this.name = name;
            BaseStream = stream;
            bf = new BinaryFormatter();
            dict = new Dictionary<S, Action<object, Connection<S>>>(1);
        }

        #region Send

        /// <summary>
        /// Send SerializableObject 
        /// </summary>
        /// <param name="obj">The SerializableObject</param>
        /// <returns>True If Send Was Seccessful</returns>
        public bool Send(SerializableObject<S> obj)
        {
            try
            {
                bf.Serialize(BaseStream, obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection || Send | "+e.Message);
                Close();
                return false;
            }
        }

        /// <summary>
        /// Create SerializableObject And Send It
        /// </summary>
        /// <param name="status">Enum</param>
        /// <param name="item">Item To Send</param>
        /// <returns>True If Send Was Seccessful</returns>
        public bool Send(S status, object item)
        {
            SerializableObject<S> obj = new SerializableObject<S>(status, item);
            return Send(obj);
        }
        /// <summary>
        /// Send SerializableObject With Only Status Object Will Be Null 
        /// </summary>
        /// <param name="status">Enum</param>
        /// <returns>True If Send Was Seccessful</returns>
        public bool Send(S status)
        {
            SerializableObject<S> obj = new SerializableObject<S>(status);
            return Send(obj);
        }

        #endregion

        /// <summary>
        /// Add Condition To The Dictionary
        /// </summary>
        /// <param name="condition">The Condition</param>
        internal void AddCondition(Condition<S> condition)
        {
            dict.Add(condition.Status, condition.Action);
        }

        /// <summary>
        /// Start The Connection
        /// </summary>
        public void Start()
        {
            stop = false;
            active = true;
            new Thread(Recive) { IsBackground = false, Name = name }.Start();
        }

        /// <summary>
        /// Stop The Connection
        /// </summary>
        public void Stop()
        {
            stop = true;
            active = false;
        }

        /// <summary>
        /// Close The Connection And The NetworkStream
        /// </summary>
        public void Close()
        {
            active = false;
            BaseStream.Close();
        }

        //Will Loop And Get SerializableObject Untill The Connection 
        //Stop/Close/Had Error/Other Side Asked To Switch
        void Recive()
        {
            while (active)
            {
                try
                {
                    while (!BaseStream.DataAvailable)
                    {
                        Thread.Sleep(10);
                        if (active)
                            continue;
                        else break;
                    }
                    SerializableObject<S> result = (SerializableObject<S>)bf.Deserialize(BaseStream);
                    if (result.Switch)
                    {
                        Stop();
                        OnChangeStatus(BaseStream);
                    }
                    else
                        dict[result.Status](result.Item, this);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    OnError?.Invoke();
                    Close();
                }
            }
            if (!stop)
                OnClose?.Invoke();
        }
    }
}
