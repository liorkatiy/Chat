using ChatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;

namespace ServerChat
{
    /// <summary>
    /// Handles All The Group Chats
    /// </summary>
    class GroupChatHandler
    {
        ServerUsers ServerUsers;
        DAL.ConnectedData dataBase;

        public GroupChatHandler(ServerUsers ServerUsers,DAL.ConnectedData data)
        {
            this.ServerUsers = ServerUsers;
            dataBase = data;
        }

        /// <summary>
        /// Start Group Chat
        /// </summary>
        /// <param name="sender">The User Ask To Start Group Chat</param>
        /// <param name="name">The Group Name</param>
        public void Start(NetUser sender, string name)
        {
            GroupChat chat = new GroupChat(sender, name);
            sender.GroupChats.Add(chat);
            sender.Send(NewGroup(chat));
            chat.Add(sender);
            dataBase.AddGroup(name, sender.Email, chat.ID);
        }

        /// <summary>
        /// Leave Group Chat
        /// </summary>
        /// <param name="sender">The User Ask To Leave</param>
        /// <param name="id">The Group ID</param>
        public void Leave(NetUser sender, Guid id)
        {
            GroupChat chat = sender.GroupChats[id];
            chat.Remove(sender);
            sender.GroupChats.Remove(chat);
        }

        /// <summary>
        /// Invite User To Group Chat
        /// </summary>
        /// <param name="sender">The User Ask For Invite</param>
        /// <param name="groupUser">Group User Containing The User To Invite And The Group ID</param>
        public void Invite(NetUser sender, GroupUser groupUser)
        {
            GroupChat chat = sender.GroupChats[groupUser.ID];
            if (chat.IsAdmin(sender))
            {
                NetUser recipient  = ServerUsers[groupUser.User];
                if (!recipient.GroupChats.Contains(groupUser.ID))
                {
                    recipient.Send(NewGroup(chat));
                    chat.Add(recipient);
                    recipient.GroupChats.Add(chat);
                }
                else
                    sender.SendError("Alredy In Group", false);
            }
            else
                sender.SendError("Not Admin", false);
        }

        /// <summary>
        /// Kick User From Group
        /// </summary>
        /// <param name="sender">The User Ask For Kick</param>
        /// <param name="groupUser">Group User Containing The User To Kick And The Group ID</param>
        public void Kick(NetUser sender, GroupUser groupUser)
        {
            GroupChat chat = sender.GroupChats[groupUser.ID];
            if (chat.IsAdmin(sender))
            {
                NetUser recipient = chat[groupUser.User];
                SerializableObject<Status> obj = 
                    new SerializableObject<Status>(Status.GroupKick, groupUser.ID);
                recipient.Send(obj);
                chat.Kick(recipient);
                recipient.GroupChats.Remove(chat);
            }
            else
                sender.SendError("Not Admin", false);
        }

        /// <summary>
        /// Send Message To All The Users In The Group
        /// </summary>
        /// <param name="sender">The User Sent The Message</param>
        /// <param name="msg">The Message</param>
        public void SendMesseage(NetUser sender, Message<Guid> msg)
        {
            try
            {
                dataBase.AddMessage(msg, sender.Email);
                GroupChat chat = sender.GroupChats[msg.ID];
                chat.SendMessage(msg);
            }
            catch(Exception e)
            {
                Console.WriteLine("GroupChatHandler|MesseageToGroupChat| User: " + sender.Name + " \nError: " + e.Message);
            }
        }

        //Create New SerializableObject With New Group Info To Send
        SerializableObject<Status> NewGroup(GroupChat chat)
        {
            NewGroup newGroup = new NewGroup(chat.ID, chat.Name, chat.GetAllUsers);
            return new SerializableObject<Status>(Status.GroupStart, newGroup);
        }
    }
}
