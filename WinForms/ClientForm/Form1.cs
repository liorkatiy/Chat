using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
namespace Chat
{
    public partial class Form1 : Form
    {
        User Me;
        TcpClient meclient;
        NetworkStream mystream;
        public Form1()
        {
            InitializeComponent();
            meclient = new TcpClient();
            byte[] adress = { 127, 0, 0, 1 };
            System.Net.IPAddress myip = new System.Net.IPAddress(adress);

            int port = 2678;
            meclient.Connect(myip, port);
            NetworkStream ns = meclient.GetStream();
            mystream = meclient.GetStream();
            FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            BinaryWriter bf = new BinaryWriter(mystream);
            bf.Write("Exit");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatBox.ForeColor = Me.Mycolor;
            ChatBox.AppendText(Me.Name +": " +TextBox.Text);
            ChatBox.AppendText("\n");
        }

        public void ResetUsers(User[] alluseres)
        {
            Users.Items.Clear();
            for (int i = 0; i < alluseres.Length; i++)
            {
                Users.Items.Add(alluseres[i]);
            }
        }

        void GetServerUsers()
        {
            NetworkStream ns = meclient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            User[] users = (User[])bf.Deserialize(ns);
            ResetUsers(users);
        }


    }
}
