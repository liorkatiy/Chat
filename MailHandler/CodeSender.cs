using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    /// <summary>
    /// Code Verification Result
    /// </summary>
    public enum CodeVerify
    {
        TryAgain,
        Success,
        Fail,
        TimeOut,
        SendCode
    }

    /// <summary>
    /// Used Only To Send Code For Email Verification
    /// </summary>
    [Serializable]
    public static class CodeSender
    {
        public static CodeVerify Send<T>(T code, NetworkStream stream) where T : IComparable
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(stream, code);
                return (CodeVerify)bf.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return CodeVerify.TimeOut;
            }
        }
    }
}
