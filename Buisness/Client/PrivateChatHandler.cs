using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatData;
using Connection;

namespace ClientChat
{
    /// <summary>
    /// Handles The Client Private Chats
    /// </summary>
    public class PrivateChatHandler
    {
        internal event Func<Status,object,bool> WriteToServer;
        Dictionary<int, PrivateChat> PrivateChats;
        MessageInfo msgInfo;

        internal PrivateChatHandler(MessageInfo msgInfo)
        {
            this.msgInfo = msgInfo;
            PrivateChats = new Dictionary<int, PrivateChat>();
        }

        /// <summary>
        /// Get Private Message And Send It To The Current Private Chat
        /// </summary>
        /// <param name="msg">The Message</param>
        internal void GetMessage(Message<int> msg)
        {
            PrivateChats[msg.ID].GetMessage(msg);
        }

        /// <summary>
        /// Close Private Chat
        /// </summary>
        /// <param name="user">The User To Close The Chat With</param>
        internal void Close(User user)
        {
            PrivateChats[user].Close();
            PrivateChats.Remove(user);
        }

        /// <summary>
        /// Create New Private Chat
        /// </summary>
        /// <param name="recipient">The User To Have Private Chat With</param>
        /// <returns></returns>
        internal PrivateChat Get(User recipient)
        {
            if (!PrivateChats.ContainsKey(recipient))
            {
                PrivateChat chat = new PrivateChat(recipient);
                chat.leaveChat += () => { Close(recipient); WriteToServer(Status.PrivateClose, recipient); };
                chat.sendMessage += (s) => WriteToServer(Status.Message, new Message<int>(msgInfo, s, recipient,MessageType.Private));
                PrivateChats.Add(recipient, chat);
                return chat;
            }
            return null;
        }

        //Send Private Message
        void SendMessage(string txt,User recipient)
        {
            WriteToServer(Status.Message, new Message<int>(msgInfo, txt, recipient,MessageType.Private));
        }

        /// <summary>
        /// Start Private Chat With User
        /// </summary>
        /// <param name="recipient">User To start Chat With</param>
        /// <returns>Returns New Private Chat</returns>
        public PrivateChat Start(User recipient)
        {
            if (!PrivateChats.ContainsKey(recipient))
            {
                WriteToServer(Status.PrivateStart, recipient);
                return Get(recipient);
            }
            return null;
        }
    }
}
