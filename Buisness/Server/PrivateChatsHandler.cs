using ChatData;
using Connection;
using System;
using DAL;

namespace ServerChat
{
    /// <summary>
    /// Handles The All The Private Chats
    /// </summary>
    class PrivateChatsHandler
    {
        ConnectedData MessageData;
        ServerUsers ServerUsers;

        public PrivateChatsHandler(ServerUsers ServerUsers, ConnectedData messageData)
        {
            this.ServerUsers = ServerUsers;
            MessageData = messageData;
        }

        // Start Private Chat With recipient User
        public void Start(NetUser sender, User recipient)
        {
            try
            {
                if (!sender.PrivateChats.Contains(recipient))
                {
                    NetUser _recipient = ServerUsers[recipient];
                    _recipient.Send(PrivateChatStatus(true, sender));
                    sender.PrivateChats.Add(_recipient);
                    _recipient.PrivateChats.Add(sender);
                }
                else
                    sender.SendError("Already In Chat", false);
            }
            catch(Exception e)
            {
                Console.WriteLine("PrivateChatsHandler|Start| User: "+sender.Name+" Error: "+e.Message);
            }
        }

        // End Private Chat With recipient User
       public void Close(NetUser sender, User recipient)
        {
            try
            {
                if (sender.PrivateChats.Contains(recipient))
                {
                    NetUser _recipient = sender.PrivateChats[recipient];
                    _recipient.Send(PrivateChatStatus(false,sender));
                    sender.PrivateChats.Remove(_recipient);
                    _recipient.PrivateChats.Remove(sender);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("PrivateChatsHandler|Close| User: " + sender.Name + " \nError: " + e.Message);
            }
        }

        // Send Message To recipient User In Private Chat
       public void SendMessage(NetUser sender, Message<int> msg)
        {
            try
            {
                NetUser recipient = sender.PrivateChats[msg.ID];
                MessageData.AddMessage(msg,sender.Email,recipient.Email);
                SerializableObject<Status> obj =
                    new SerializableObject<Status>(Status.Message, msg);
                sender.Send(obj);
                msg.ChangeID(sender);
                recipient.Send(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine("PrivateChatsHandler|SendMessage| User: " + sender.Name + " \nError: " + e.Message);
            }
        }

        //Create SerializableObject To Start/End Private Chat
        SerializableObject<Status> PrivateChatStatus(bool start, User u)
        {
            Status s = start ? Status.PrivateStart : Status.PrivateClose;
            return new SerializableObject<Status>(s, u);
        }

    }
}
