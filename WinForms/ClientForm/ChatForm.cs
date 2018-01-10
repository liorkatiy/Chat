using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ChatData;
using WinFormsExtensions;
using ClientChat;
using System.Net;

namespace ClientForm
{
    public partial class ChatForm : Form
    {
        Client client;

        public ChatForm(LoginInfo loginInfo, Client client)
        {
            InitializeComponent();
            Name = loginInfo.Name;
            this.client = client;
            client.OnStartPrivateChat += StartPrivateChat;
            client.OnStartGroupChat += StartGroupChat;
            client.OnInitializeUserList += InitializeUserList;
            client.OnUpdateUserList += UpdateUserList;
            client.OnGetMessage += UpdateGlobalChat;
            client.OnError += OnError;
            Shown += (o, s) => client.Login(loginInfo);
        }

        //Send Message Button Click
        private void BtnSend_Click(object sender, EventArgs e)
        {
            client.SendMessage(TextBox.Text);
            TextBox.Clear();
        }

        //TextBox Key Press
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSend_Click(sender, e);
        }

        //Form Closing Event
        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        //Start Private Chat Double Click On User
        private void StartPrivateChat(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedItem != null)
            {
                User recipient = (User)UsersListBox.SelectedItem;
                client.StartPrivateChat(recipient);
            }
        }

        //Start Group Chat Button 
        private void StartGroupBtn_Click(object sender, EventArgs e)
        {
            StartGroupForm startGroup = new StartGroupForm(client.StartGroupChat);
            startGroup.Show();
        }

        //Mouse Hover Users ListBox
        private void Users_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Double Click On User To Start Private Chat", UsersListBox);
        }

        #region(Client Events)

        void OnError(Error error)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(error.Message);
                if (error.Critical)
                    Close();
            }));
        }

        void UpdateGlobalChat(ChatData.Message msg)
        {
            ChatBox.AppendMessage(msg);
        }

        void UpdateUserList(User user, bool join)
        {
            Invoke(new Action(() =>
            {
                if (join)
                    UsersListBox.Items.Add(user);
                else
                    UsersListBox.Items.Remove(user);
            }
            ));
        }

        void InitializeUserList(User[] users)
        {
            Invoke(new Action(() =>
            {
                for (int i = 0; i < users.Length; i++)
                {
                    UsersListBox.Items.Add(users[i]);
                }
            }));
        }

        void StartPrivateChat(PrivateChat chat)
        {
            Invoke(new Action(() =>
            {
                if (chat != null)
                {
                    PrivateChatForm f = new PrivateChatForm(chat);
                    tabs.AddTabWithControl(chat.Name, f);
                }
            }));

        }

        void StartGroupChat(GroupChat chat, User[] users)
        {
            Invoke(new Action(() =>
            {
                if (chat != null)
                {
                    GroupChatForm f = new GroupChatForm(chat, users, UsersListBox);
                    tabs.AddTabWithControl(chat.Name, f);
                }
            }));

        }
        #endregion
    }
}