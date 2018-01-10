using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientChat;
using System.Net;

namespace ClientForm
{
    public partial class RegisterForm : Form
    {
        Client client;

        public RegisterForm(Client client)
        {
            this.client = client;
            client.OnError += OnError;
            client.OnRegister += OnRegister;
            InitializeComponent();
            SendBtn.Hide();
            CodeTextBox.Hide();
        }

        //Register Button Click
        private void RegBtn_Click(object sender, EventArgs e)
        {
            ChatData.RegisterInfo registerInfo = new ChatData.RegisterInfo(MailTextBox.Text, PasswordTextBox.Text);
            client.Register(registerInfo);
        }

        //Send Code Button Click
        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (client.SendCode(int.Parse(CodeTextBox.Text)))
            {
                MessageBox.Show("Registered");
                client.Close();
                Close();
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        #region Client Events

        void OnError(ChatData.Error error)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(error.Message, "ERROR");
                if (error.Critical)
                {
                    Close();
                    client.Close();
                }
            }));
        }

        void OnRegister(bool mailNeeded)
        {
            Invoke(new Action(() =>
            {
                if (mailNeeded)
                {
                    CodeTextBox.Show();
                    SendBtn.Show();
                    Size = new Size(251, Size.Height);
                    MessageBox.Show("Please Enter Code");
                }
                else
                {
                    MessageBox.Show("Registered!");
                    Close();
                }
            }));
        }

        #endregion
    }
}
