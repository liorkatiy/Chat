using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatData;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientChat
{
    /// <summary>
    /// Contains The Saved Data
    /// </summary>
    [Serializable]
    public struct ClientData
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public MessageInfo MessageInfo { get; private set; }

        public ClientData(string email, string password, MessageInfo msgInfo)
        {
            Email = email;
            Password = password;
            MessageInfo = msgInfo;
        }
    }

    /// <summary>
    /// Save/Load Client Info
    /// </summary>
    public class ClientInfo
    {
        BinaryFormatter bf;
        string filePath;

        public ClientInfo(string filePath)
        {
            bf = new BinaryFormatter();
            this.filePath = filePath;
        }

        /// <summary>
        /// Save The Client Info
        /// </summary>
        /// <param name="info"></param>
        public void Save(ClientData info)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
                bf.Serialize(fs, info);
        }

        /// <summary>
        /// Load The Client Info If No File Was Saved Return Empty Client Data
        /// </summary>
        /// <returns></returns>
        public ClientData Load()
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    return (ClientData)bf.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine("ClientInfo|| Load| ", e.Message);
                return new ClientData(string.Empty, string.Empty, MessageInfo.Empty);
            }
        }
    }
}