using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Net.Sockets;
using WinFormsExtensions;

namespace ServerForm
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            MailCheckBox.Checked = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (ipTextBox.CanGetIP(out ip))
            {
                IPEndPoint endPoint = new IPEndPoint(ip, (int)Port.Value);
                string smtp = SmtpTextBox.Text;
                int port = (int)MailPort.Value;
                bool ssl = SSLCheckBox.Checked;
                string username = UserNameTextBox.Text;
                string password = PasswordTextBox.Text;
                ServerForm form;
                if (MailCheckBox.Checked)
                    form = new ServerForm((int)UserAmount.Value, ConnectionStringTextBox.Text, endPoint, smtp, port, ssl, username, password);
                else
                    form = new ServerForm((int)UserAmount.Value, endPoint, ConnectionStringTextBox.Text);
                form.Show();
                Hide();
                form.FormClosed += (o, arg) => Show();
            }
        }

        private void MailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MailCheckBox.Checked)
            {
                Height = 440;
                MailGroup.Show();
            }
            else
            {
                Height = 200;
                MailGroup.Hide();
            }
        }
    }
}
