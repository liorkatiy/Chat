using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Collections.Concurrent;
using ChatData;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    /// <summary>
    /// Struct To Keep All The Messages
    /// </summary>
    struct MessageDB
    {
        Message msg;
        public string Sender { get { return msg.Sender; } }
        public string Text { get { return msg.Text; } }
        public MessageType MessageType { get { return msg.Type; } }
        public string Email { get; private set; }
        public string RecipientEmail { get; private set; }
        public string GroupID { get { return ((Message<Guid>)msg).ID.ToString(); } }

        public MessageDB(Message msg, string email)
        {
            this.msg = msg;
            Email = email;
            RecipientEmail = string.Empty;
        }

        public MessageDB(Message msg, string senderEmail, string recipientEmail) : this(msg, senderEmail)
        {
            RecipientEmail = recipientEmail;
        }
    }

    /// <summary>
    /// Class That Handles Inserting Messages To DataBase
    /// </summary>
    class MessageHandler:ConnectionToDataBase
    {
        ConcurrentQueue<MessageDB> messageQ;
        bool active;
        SqlCommand msgCOM;
        readonly int sleepTime;
        readonly int workTime;

        /// <summary>
        /// Start The Message Handler
        /// </summary>
        /// <param name="active">Time In Seconds That The Message Handler Dequeue Messages</param>
        /// <param name="sleep">Time In Seconds That The Message Handler Sleep Before Going Back To Dequeueing</param>
        public MessageHandler(double active,double sleep,string connectionString)
            :base(connectionString)
        {
            this.active = true;
            sleepTime = (int)(sleep*1000);
            workTime = (int)(active*1000);
            messageQ = new ConcurrentQueue<MessageDB>();

            msgCOM = new SqlCommand("AddMessage")
            { CommandType = CommandType.StoredProcedure };
            SqlParameter[] messageParameters = {
                new SqlParameter("@sender", SqlDbType.NVarChar,50),
                new SqlParameter("@txt", SqlDbType.NVarChar,500),
                new SqlParameter("@email", SqlDbType.NVarChar,50)
            };
            msgCOM.Parameters.AddRange(messageParameters);
            new Thread(DequeueMesseages)
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = false
            }.Start();
        }

        //While The Message Handler Is Active Keep Adding Messages To The DataBase
        void DequeueMesseages()
        {
            Stopwatch sw = new Stopwatch();
            List<MessageDB> list = new List<MessageDB>();
            MessageDB msg;
            while (active)
            {
                Thread.Sleep(sleepTime);
                sw.Start();
                while (messageQ.Count > 0 && sw.ElapsedMilliseconds < workTime)
                {
                    if (messageQ.TryDequeue(out msg))
                        list.Add(msg);
                }
                if (list.Count > 0)
                    AddMesseagesToDataBase(list);
                sw.Reset();
                list.Clear();
            }

            while (messageQ.Count > 0)
            {
                if (messageQ.TryDequeue(out msg))
                    list.Add(msg);
            }
            AddMesseagesToDataBase(list);
        }

        //Start Adding Messages To The DataBase
        void AddMesseagesToDataBase(List<MessageDB> msgdb)
        {
            try
            {
                using (SqlConnection sn = GetConnection)
                {
                    sn.Open();
                    msgCOM.Connection = sn;
                    for (int i = 0; i < msgdb.Count; i++)
                    {
                        msgCOM.Parameters["@sender"].Value = msgdb[i].Sender;
                        msgCOM.Parameters["@txt"].Value = msgdb[i].Text;
                        msgCOM.Parameters["@email"].Value = msgdb[i].Email;
                        switch (msgdb[i].MessageType)
                        {
                            case MessageType.Global:
                                msgCOM.ExecuteNonQuery();
                                break;
                            case MessageType.Private:
                                ExecuteWithParam("@recipientEmail", msgdb[i].RecipientEmail);
                                break;
                            case MessageType.Group:
                                ExecuteWithParam("@GroupID", msgdb[i].GroupID);
                                break;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Close();
            }
        }

        void ExecuteWithParam(string name, string value)
        {
            msgCOM.Parameters.Add(name, SqlDbType.NVarChar, value.Length).Value = value;
            msgCOM.ExecuteNonQuery();
            msgCOM.Parameters.RemoveAt(name);
        }

        /// <summary>
        /// AddMessage To The Message Queue
        /// </summary>
        /// <param name="msg"></param>
        internal void Add(MessageDB msg)
        {
            messageQ.Enqueue(msg);
        }

        /// <summary>
        /// Close The Message Handler
        /// </summary>
        internal void Close()
        {
            active = false;
        }
    }
}
