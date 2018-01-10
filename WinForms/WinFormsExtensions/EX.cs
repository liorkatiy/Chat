using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions
{
    public static class EX
    {
        /// <summary>
        /// Appends The Message To The TextBox
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="msg"></param>
        public static void AppendMessage(this RichTextBox textbox, ChatData.Message msg)
        {
            textbox.Invoke(new Action(() =>
            {
                if (msg.IsAlert)
                {
                    textbox.SelectionColor = Color.Black;
                    textbox.AppendText(msg.Text + " \n");
                }
                else
                {
                    textbox.SelectionColor = Color.Black;
                    textbox.AppendText(msg.Sender + ": ");
                    textbox.SelectionColor = msg.Color;
                    textbox.AppendText(msg + " \n");
                }
            }));
        }

        /// <summary>
        /// Add Tab With Control
        /// </summary>
        /// <param name="tabs"></param>
        /// <param name="name"></param>
        /// <param name="control"></param>
        public static void AddTabWithControl(this TabControl tabs, string name, Control control)
        {
            TabPage tab = new TabPage(name);
            tab.Controls.Add(control);
            tabs.TabPages.Add(tab);
        }
    }
}
