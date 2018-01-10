using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WinFormsExtensions
{
    public partial class IPTextBox : UserControl
    {
        public IPTextBox()
        {
            InitializeComponent();
        }

        public bool CanGetIP(out IPAddress IP)
        {
            string IPstr = box1.Text + "." + box2.Text + "." + box3.Text + "." + box4.Text;
            if (IPAddress.TryParse(IPstr, out IP))
                return true;
            MessageBox.Show("Invalid IP Adress");
            return false;
        }

        private void box_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox t = (MaskedTextBox)sender;
            if (t.SelectionStart == 2||e.KeyChar ==' ')
            {
                SelectNextControl(t, true, true, false, false);
            }
        }

        private void box_MouseClick(object sender, MouseEventArgs e)
        {
            ((MaskedTextBox)sender).Clear();
        }

        private void IPTextBox_FontChanged(object sender, EventArgs e)
        {
            int x = box1.Size.Width;
            box1.Location = new Point(0, 0);
            box2.Location = new Point(x, 0);
            box3.Location = new Point(x + x, 0);
            box4.Location = new Point(x + x + x, 0);
            Size = new Size(x * 4, box1.Size.Height);
        }
    }
}
