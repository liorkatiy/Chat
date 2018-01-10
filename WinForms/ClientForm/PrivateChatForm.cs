using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientChat;
using ChatData;
using WinFormsExtensions;

namespace ClientForm
{
    public partial class PrivateChatForm : UserControl
    {
        PrivateChat chat;

        public PrivateChatForm(PrivateChat chat)
        {
            InitializeComponent();
            this.chat = chat;
            chat.OnClose += OnClose;
            chat.OnGetMessage += OnGetMessage;
        }

        //Send Button Click
        private void BtnSend_Click(object sender, EventArgs e)
        {
            chat.SendMessage(textBox.Text);
            textBox.Clear();
        }

        //Button Click Click
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            chat.Leave();
        }

        #region Private Chat Events
        public void OnClose()
        {
            Invoke(new Action(() =>
                ((TabControl)(((TabPage)Parent).Parent)).TabPages.Remove((TabPage)Parent)
            ));
        }

        public void OnGetMessage(ChatData.Message msg)
        {
            Invoke(new Action(() =>
            {
                chatBox.AppendMessage(msg);
            }));
        }
        #endregion
    }
}
