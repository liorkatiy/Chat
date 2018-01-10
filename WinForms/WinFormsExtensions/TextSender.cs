using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions
{
    public partial class TextSender : UserControl
    {
        public event Action OnSendClick;

        public TextSender()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OnSendClick();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            OnSendClick();
        }
    }
}
