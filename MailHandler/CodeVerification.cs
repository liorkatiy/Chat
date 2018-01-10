using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.IO;
using Connection;

namespace Mail
{
    /// <summary>
    /// Class Used To Verify Email 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CodeVerification<T> where T : IComparable
    {
        sbyte tryamount;
        T code;
        BinaryFormatter bf;
        Connection<CodeVerify> connection;
        bool outOfTime;


        public CodeVerification(T code, sbyte tryamount)
        {
            bf = new BinaryFormatter();
            this.code = code;
            this.tryamount = tryamount;
            ConnectionFactory<CodeVerify> factory = new ConnectionFactory<CodeVerify>();
            factory.Add<T>(CodeVerify.SendCode, GetCode);
        }

        /// <summary>
        /// Wait For The Other User To Send Code
        /// </summary>
        /// <param name="stream">The NetWorkStream</param>
        /// <param name="ReadTimeOut">Time In Seconds Before Disconnecting</param>
        /// <returns></returns>
        public bool Verify(NetworkStream stream,float ReadTimeOut)
        {
            stream.ReadTimeout = (int)(ReadTimeOut*1000);
            try
            {
                T result = GetCode(stream);
                while (result.CompareTo(code) != 0)
                {
                    if (tryamount <= 0)
                    {
                        bf.Serialize(stream, CodeVerify.Fail);
                        return false;
                    }
                    bf.Serialize(stream, CodeVerify.TryAgain);
                    result = GetCode(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("CodeVerification || Verify: {0}", e.Message);
                return false;
            }
            bf.Serialize(stream, CodeVerify.Success);
            return true;
        }

        bool Timer(float time)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            time *= 1000;
            sw.Start();
            while (sw.ElapsedMilliseconds < time)
            {
                System.Threading.Thread.Sleep(100);
            }
            sw.Stop();
            outOfTime = true;
            connection.Send(CodeVerify.TimeOut);
            connection.Close();
            return false;
        }

        void GetCode(T codeSent)
        {
            if (codeSent.CompareTo(code) == 0)
            {
                connection.Send(CodeVerify.Success);
                connection.Close();
            }
            else if (tryamount > 0)
                connection.Send(CodeVerify.TryAgain);
            else
            {
                connection.Send(CodeVerify.Fail);
                connection.Close();
            }
            tryamount--;
        }

        T GetCode(NetworkStream stream)
        {
            tryamount--;
            return (T)bf.Deserialize(stream);
        }
    }
}
