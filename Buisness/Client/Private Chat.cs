using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatData;

namespace ClientChat
{
    /// <summary>
    /// Private Chat Object
    /// </summary>
    public class PrivateChat
    {
        /// <summary>
        /// Recipient Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Happens When Chat Is Closing
        /// </summary>
        public event Action OnClose;

        /// <summary>
        /// Happens When Get New Message
        /// </summary>
        public event Action<Message> OnGetMessage;

        internal event Action<string> sendMessage;
        internal event Action leaveChat;

        internal PrivateChat(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Send Private Message
        /// </summary>
        /// <param name="msg">Message Text</param>
        public void SendMessage(string msg)
        {
            sendMessage(msg);
        }

        /// <summary>
        /// Leave Private Chat
        /// </summary>
        public void Leave()
        {
            leaveChat();
        }

        /// <summary>
        /// Calls The OnGetMessageEvent
        /// </summary>
        /// <param name="msg"></param>
        internal void GetMessage(Message msg)
        {
            OnGetMessage(msg);
        }

        /// <summary>
        /// Calls The OnClose Event
        /// </summary>
        internal void Close()
        {
            OnClose();
        }
    }
}
