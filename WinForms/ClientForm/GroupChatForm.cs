using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsExtensions;
using ChatData;
using ClientChat;


namespace ClientForm
{
    public partial class GroupChatForm : UserControl
    {
        //AllThe Users In Global Chat
        ListBox AllUsers;
        GroupChat chat;
        public GroupChatForm(GroupChat chat,User[] users,ListBox AllUsers)
        {
            InitializeComponent();
            this.chat = chat;
            chat.OnClose += OnClose;
            chat.OnGetMessage += GetMessage;
            chat.OnUserUpdateState += UpdateUser;
            InitializeUsers(users);
            this.AllUsers = AllUsers;
        }

        //Initialize The Users List Box
        void InitializeUsers(User[] users)
        {
            if (users.Length != 0)
            {
                InviteBtn.Enabled = false;
                KickBtn.Enabled = false;
                UsersList.Enabled = false;
            }
            for (int i = 0; i < users.Length; i++)
            {
                UsersList.Items.Add(users[i]);
            }
        }

        //Quit Button Press
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            chat.Leave();
        }

        //Invite Button Press
        private void InviteBtn_Click(object sender, EventArgs e)
        {
            foreach (User u in AllUsers.SelectedItems)
            {
               chat.Invite(u);
            }
        }

        //Kick Button Press
        private void KickBtn_Click(object sender, EventArgs e)
        {
            foreach (User u in UsersList.SelectedItems)
            {
                chat.Kick(u);
            }
        }

        //Send Button Press
        private void SendBtn_Click(object sender, EventArgs e)
        {
            chat.SendMessage(TextBox.Text);
        }

        #region Group Chat Events
        void OnClose()
        {
            Invoke(new Action(() =>
            ((TabControl)(((TabPage)Parent).Parent)).TabPages.Remove((TabPage)Parent)));
        }

        void GetMessage(ChatData.Message msg)
        {
            Invoke(new Action(() =>
            ChatBox.AppendMessage(msg)));
        }

        void UpdateUser(User user, bool join)
        {
            Invoke(new Action(() =>
            {
                if (join)
                {
                    UsersList.Items.Add(user);
                }
                else
                {
                    UsersList.Items.Remove(user);
                }
            }));
        }
        #endregion
    }
}
