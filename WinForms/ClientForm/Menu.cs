using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientChat;
using ChatData;

namespace ClientForm
{
    public partial class Menu : Form
    {
        ClientInfo clientInfo;

        public Menu()
        {
            InitializeComponent();
            clientInfo = new ClientInfo("UserInfo.Info");
            ClientData data = clientInfo.Load();
            Shown += (a, b) =>
            {
                EmailTextBox.Text = data.Email;
                PasswordTextBox.Text = data.Password;
                MyColorDialogBox.Color = data.MessageInfo.Color;
                btnColor.BackColor = data.MessageInfo.Color;
                NameBox.Text = data.MessageInfo.Name;
            };
        }

        //Logion Button Press
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            IPEndPoint IP;
            if (CanGetIP(out IP))
            {
                LoginInfo loginInfo = new LoginInfo(NameBox.Text, EmailTextBox.Text, PasswordTextBox.Text);
                MessageInfo msgInfo = new MessageInfo(MyColorDialogBox.Color, NameBox.Text);
                Client client = new Client(IP, msgInfo);
                ChatForm chat = new ChatForm(loginInfo, client);
                chat.Show();
                Hide();
                chat.FormClosed += (o, arg) => Show();
            }
        }

        //Color Button Click
        private void BtnColor_Click(object sender, EventArgs e)
        {
            MyColorDialogBox.ShowDialog();
            btnColor.BackColor = MyColorDialogBox.Color;
        }

        //Register Button Click Open New Register Form
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            IPEndPoint IP;
            if (CanGetIP(out IP))
            {
                Client client = new Client(IP);
                RegisterForm r = new RegisterForm(client);
                r.Show();
                Hide();
                r.FormClosed += (a, b) => Show();
            }
        }

        //Chck If IP Is Valid And Outs The IP
        bool CanGetIP(out IPEndPoint IP)
        {
            IPAddress ip;
            IP = null;
            if (ipTextBox.CanGetIP(out ip))
            {
                IP = new IPEndPoint(ip, (int)Port.Value);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Save Button Click
        private void SaveData(object sender, EventArgs e)
        {
            MessageInfo msgInfo = new MessageInfo(MyColorDialogBox.Color, NameBox.Text);
            ClientData data = new ClientData(EmailTextBox.Text, PasswordTextBox.Text, msgInfo);
            clientInfo.Save(data);
            MessageBox.Show("Saved Email, Password,Name,Color");
        }
    }
}
