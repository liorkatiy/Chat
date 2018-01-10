using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
 
namespace ServerForm
{
    public partial class PrivateChatForm : Form
    {
        DisconnectedData Db;

        public PrivateChatForm(List<string> users,string userName,DisconnectedData Db)
        {
            InitializeComponent();
            this.Db = Db;
            Name = userName;
            listBox1.DataSource = users;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                dataGridView1.DataSource = Db.GetPrivateChat(Name, listBox1.SelectedItem.ToString());
            }
        }
    }
}
