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
        string cn;

        public Menu()
        {
            InitializeComponent();
            MailCheckBox.Checked = false;
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (ipTextBox1.CanGetIP(out ip))
            {
                string cn = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + GetDataBaseDirectory.Get() + "; Integrated Security = True";
                IPEndPoint endPoint = new IPEndPoint(ip, (int)Port.Value);
                string smtp = SmtpTextBox.Text;
                int port = (int)MailPort.Value;
                bool ssl = SSLCheckBox.Checked;
                string username = UserNameTextBox.Text;
                string password = PasswordTextBox.Text;
                ServerForm form;
                if (MailCheckBox.Checked)
                    form = new ServerForm((int)UserAmount.Value, cn, endPoint, smtp, port, ssl, username, password);
                else
                    form = new ServerForm((int)UserAmount.Value, endPoint, cn);
                form.Show();
                Hide();
                form.FormClosed += (o, arg) => Show();
            }
        }

        private void MailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MailCheckBox.Checked)
            {
                Height = 360;
                MailGroup.Show();
            }
            else
            {
                Height = 150;
                MailGroup.Hide();
            }
        }
    }
}
