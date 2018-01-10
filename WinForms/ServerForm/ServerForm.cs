using ChatData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsExtensions;
using ServerChat;
using DAL;
using System.Net;

namespace ServerForm
{
    public partial class ServerForm : Form
    {
        Server server;
        DisconnectedData data;
        int currentUsersInChat;

        public ServerForm(int amountOfUsers,string connectionString, IPEndPoint ip, string smtp, int port, bool ssl, string username, string password)
        {
            server = new Server(amountOfUsers, connectionString, smtp, port, ssl, username, password);
            InitializeForm(ip, amountOfUsers, connectionString);
        }

        public ServerForm(int amountOfUsers, IPEndPoint ip,string connectionString)
        {
            server = new Server(amountOfUsers, connectionString);
            InitializeForm(ip, amountOfUsers, connectionString);
        }

        void InitializeForm(IPEndPoint ip,int maxusers, string connectionString)
        {
            InitializeComponent();
            MaxUsersAmount.Text = maxusers.ToString();
            currentUsersInChat = 0;
            data = new DisconnectedData(connectionString);
            GetUsersByComboBox.SelectedItem = GetUsersByComboBox.Items[0];

            Shown += (o, arg) => OnFormShown(ip);
        }

        void OnFormShown(IPEndPoint ip)
        {
            string error;
            if (server.Start(ip, out error))
            {
                server.OnClientJoin += OnClientJoin;
                server.OnClientLeft += OnClientLeft;
                server.OnNewMessage += (msg) =>
                Invoke(new Action(() =>
                ChatBox.AppendMessage(msg)
                ));
            }
            else
            {
                MessageBox.Show(error);
                Close();
            }
        }

        #region Server Events

        void OnClientJoin(NetUser u)
        {
            Invoke(new Action(() =>
            {
                string[] info = { u.Name, u.ID.ToString() };
                UsersInfo.Items.Add(new ListViewItem(info)
                { Name = info[1] });
                currentUsersAmount.Text = (++currentUsersInChat).ToString();
            }));
        }

        void OnClientLeft(NetUser u)
        {
            Invoke(new Action(() =>
            {
                if (!Disposing)
                {
                    UsersInfo.Items.RemoveByKey(u.ID.ToString());
                    currentUsersAmount.Text = (--currentUsersInChat).ToString();
                }
            }));
        }
        #endregion

        //Send Message Send
        private void SendBtn_Click(object sender, EventArgs e)
        {
            server.SendMessageToAllUsers(ServerChat.Text);
            ServerChat.Clear();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }

        //Kick Button Click Select Only The Checked Users And Kick Them
        private void KickBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersInfo.Items.Count; i++)
            {
                if (UsersInfo.Items[i].Checked)
                {
                    string id = UsersInfo.Items[i].SubItems[1].Text;
                    server.Kick(int.Parse(id));
                }
            }
        }

        //Get Private Chat Button Open New Private Chat Form By The Select Row
        private void PrivateBtn_Click(object sender, EventArgs e)
        {
            if (DataBaseUsers.CurrentRow != null)
            {
                string userName = DataBaseUsers.CurrentRow.Cells[0].Value.ToString();
                List<string> users = data.GetPrivateChatUsers(userName);
                PrivateChatForm pcf = new PrivateChatForm(users, userName, data);
                pcf.Show();
            }
        }

        //Delete User Button Click
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DataBaseUsers.SelectedRows != null)
            {
                foreach (DataGridViewRow row in DataBaseUsers.SelectedRows)
                {
                    string Email = row.Cells["Email"].Value.ToString();
                    data.DeleteUser(Email);
                    if (row.Cells["ID"].Value is int)
                        server.Kick((int)row.Cells["ID"].Value);
                }
            }
            GetUsersBtn_Click(this, EventArgs.Empty);
        }

        //Get Message CheckBox Check Changed Will Display Text If Checked Date If Not Checked
        private void GetMessageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GetMessageCheckBox.Checked)
            {
                MessageByText.Show();
                MessageByDate.Hide();
                GetByDatePart.Hide();
            }
            else
            {
                MessageByText.Hide();
                MessageByDate.Show();
                GetByDatePart.Show();
            }
        }

        //Get Message Button Click Will Get Message By Date Or By Text
        private void GetMessagesBtn_Click(object sender, EventArgs e)
        {
            if (GetMessageCheckBox.Checked)
            {
                DataBaseMessages.DataSource = data.GetMessages(MessageByText.Text);
            }
            else
            {
                DateBy dateBy = GetByDatePart.Checked ? DateBy.Day : DateBy.Minute;
                DataBaseMessages.DataSource = data.GetMessages(MessageByDate.Value, dateBy);
            }
        }

        //When Select New Item In The Combo Box Show The Proper Controls
        private void GetUsersByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (GetUsersByComboBox.SelectedIndex)
            {
                case 0://All Users
                    UserText.Hide();
                    UserDate.Hide();
                    break;
                case 1://Only Connected
                    UserText.Hide();
                    UserDate.Hide();
                    break;
                case 2://Email
                    UserText.Show();
                    UserDate.Hide();
                    break;
                case 3://Nick Name
                    UserText.Show();
                    UserDate.Hide();
                    break;
                case 4://Lase Connection Date
                    UserText.Hide();
                    UserDate.Show();
                    break;
            }
        }

        //Get Users Button Click 
        private void GetUsersBtn_Click(object sender, EventArgs e)
        {
            switch (GetUsersByComboBox.SelectedIndex)
            {
                case 0://All Users
                    DataBaseUsers.DataSource = data.GetUserBy(UserBy.All);
                    break;
                case 1://Only Connected
                    DataBaseUsers.DataSource = data.GetUserBy(UserBy.Connected);
                    break;
                case 2://Email
                    DataBaseUsers.DataSource = data.GetUserBy(UserBy.Email, UserText.Text);
                    break;
                case 3://Nick Name
                    DataBaseUsers.DataSource = data.GetUserBy(UserBy.Name, UserText.Text);
                    break;
                case 4://Lase Connection Date
                    DataBaseUsers.DataSource = data.GetUserBy(UserDate.Value);
                    break;
            }
            DataBaseUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void Users_Enter(object sender, EventArgs e)
        {
            DataBaseUsers.DataSource = data.GetUserBy(UserBy.All);
        }

        //Group Chat Button
        private void GroupBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Working Yet");
        }
    }
}
