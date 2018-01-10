using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class StartGroupForm : Form
    {
        Action<string> StartChat;
        public StartGroupForm(Action<string> startchat)
        {
            InitializeComponent();
            StartChat = startchat;
        }

        //Start Button Click
        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartChat(NameBox.Text);
            Close();
        }
    }
}
