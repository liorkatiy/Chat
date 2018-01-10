using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.IO;
using ChatData;
using System.Drawing;

namespace Client
{
    class clientthings
    {
        TcpClient client;
        public BinaryReader reader;
        public BinaryWriter writer;
        public BinaryFormatter bf;
        NetworkStream ns;

        event Action<string, User> UpdateTextBox;
        event Action<User[]> UpdateUserList;

        public clientthings(string name, Color color, Action<string, User> updatetextbox, Action<User[]> updateuserlist)
        {
            UpdateTextBox = updatetextbox;
            UpdateUserList = updateuserlist;
            client = new TcpClient();
            client.Connect(Data.IP, Data.Port);
            ns = client.GetStream();
            reader = new BinaryReader(ns);
            writer = new BinaryWriter(ns);
            bf = new BinaryFormatter();
            int id = reader.ReadInt32();
            bf.Serialize(ns, new User(name, color, id));
            Thread t = new Thread(ReadFromServer);
            t.Start();
        }

        void ReadFromServer()
        {
            Thread.Sleep(5);
            while (client.Connected)
            {
                try
                {
                    Status s = (Status)reader.ReadInt32();
                    switch (s)
                    {
                        case Status.UpdateChatBox:
                            string txt = reader.ReadString();
                            User c = (User)bf.Deserialize(ns);
                            UpdateTextBox(txt,c);
                            break;
                        case Status.UsersUpdate:
                            User[] users = (User[])bf.Deserialize(ns);
                            UpdateUserList(users);
                            break;
                    }
                }
                catch
                {
                    Close();
                }
            }
        }

        public void WriteMsgToChat(string txt)
        {
            writer.Write((int)Status.SendMsgToChat);
            writer.Write(txt);
            writer.Flush();
        }

        public void WriteMsgToPrivateChat(string txt)
        {
            writer.Write((int)Status.StartPrivateChat);
            writer.Write(txt);
            writer.Flush();
        }

        public void Close()
        {
            client.Close();
            reader.Close();
            writer.Close();
            ns.Close();
        }
    }
}
