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
    /// Handles The Client Group Chats
    /// </summary>
    internal class GroupChatHandler
    {
        internal event Func<Status,object,bool> WriteToServer;
        Dictionary<Guid, GroupChat> GroupChats;
        MessageInfo msgInfo;

        internal GroupChatHandler(MessageInfo msgInfo)
        {
            GroupChats = new Dictionary<Guid, GroupChat>();
            this.msgInfo = msgInfo;
        }

        /// <summary>
        /// Start Group Chat
        /// </summary>
        /// <param name="Name">Group Name</param>
        public void Start(string Name)
        {
            WriteToServer(Status.GroupStart,Name);
        }

        /// <summary>
        /// Get Group Chat Object
        /// </summary>
        /// <param name="gcu">NewGroup Object</param>
        /// <returns></returns>
        internal GroupChat Get(NewGroup gcu)
        {
            if (!GroupChats.ContainsKey(gcu.ID))
            {
                GroupChat chat = new GroupChat(gcu.Name);
                GroupChats.Add(gcu.ID, chat);
                chat.InviteToGroup += (u) => GroupUser(new GroupUser(gcu.ID, u), true);
                chat.KickFromGroup += (u) => GroupUser(new GroupUser(gcu.ID, u), false);
                chat.sendMessage += (s) => SendMessage(s, gcu.ID);
                chat.leaveChat += () => { Close(gcu.ID); WriteToServer(Status.GroupLeave, gcu.ID); };
                return chat;
            }
            return null;
        }

        /// <summary>
        /// Update Message To Group
        /// </summary>
        /// <param name="msg"></param>
        internal void GetMessage(Message<Guid> msg)
        {
            GroupChats[msg.ID].GetMessage(msg);
        }

        /// <summary>
        /// Update User State With Group
        /// </summary>
        /// <param name="userstatus">Group User Status Object</param>
        internal void UserStatus(GroupUserStatus userstatus)
        {
            GroupChat chat = GroupChats[userstatus.ID];
            chat.UserUpdateState(userstatus.User, userstatus.Join);
            chat.GetMessage(userstatus.Message);
        }

        /// <summary>
        /// Close Group Chat With The ID
        /// </summary>
        /// <param name="ID"></param>
        internal void Close(Guid ID)
        {
            GroupChats[ID].Close();
            GroupChats.Remove(ID);
        }

        //Ask The Server For Invite Or Kick
        void GroupUser(GroupUser u, bool invite)
        {
            if (invite)
                WriteToServer(Status.GroupInvite, u);
            else
                WriteToServer(Status.GroupKick, u);
        }

        //Send Message To Group Chat
        void SendMessage(string txt, Guid ID)
        {
            WriteToServer(Status.Message, new Message<Guid>(msgInfo, txt, ID,MessageType.Group));
        }
    }
}
