using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChatData
{
    /// <summary>
    /// The Message Type
    /// </summary>
    public enum MessageType
    {
        Global, Private, Group
    }

    /// <summary>
    /// Message To Send 
    /// </summary>
    [Serializable]
    public class Message
    {
        public virtual MessageType Type { get { return MessageType.Global; } }
        public string Text { get; private set; }
        public string Sender { get; private set; }
        public Color Color { get; private set; }
        public bool IsAlert { get; private set; }

        public Message(string txt):this(MessageInfo.Empty, txt)
        {
            IsAlert = true;
        }

        public Message(MessageInfo info,string txt)
        {
            Text = txt;
            Sender = info.Name;
            Color = info.Color;
            IsAlert = false;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// Message With ID
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Message<T>:Message
    {
        public T ID { get; private set; }
        public override MessageType Type
        {
            get
            {
                if (ID is int)
                    return MessageType.Private;
                return MessageType.Group;
            }
        }
        public Message(MessageInfo info, string txt, T ID,MessageType msgType) : base(info, txt)
        {
            this.ID = ID;
        }

        public Message<T> ChangeID(T ID)
        {
            this.ID = ID;
            return this;
        }
    }
}
