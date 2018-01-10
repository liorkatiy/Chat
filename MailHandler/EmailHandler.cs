using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace Mail
{
    public class EmailHandler
    {
        Random rnd = new Random();
        SmtpClient client;
        string myemail;

        public EmailHandler(MailInfo mailInfo)
        {
            myemail = mailInfo.UserName;
            client = new SmtpClient()
            {
                Host = mailInfo.Smtp,
                Port = mailInfo.Port,
                EnableSsl = mailInfo.SSL,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(mailInfo.UserName, mailInfo.Password)
            };
        }

        /// <summary>
        /// Send Email To Given Address Return True If Manged To Send The email
        /// </summary>
        /// <param name="toAddress">The Adress To Send The Email To</param>
        /// <param name="codeVerify">Outs New Code Verification</param>
        /// <returns></returns>
        public bool SendMail(string toAddress,out CodeVerification<int> codeVerify)
        {
            string subject = "Verify mail";
            int code = rnd.Next();
            codeVerify = new CodeVerification<int>(code, 3);
            try
            {
                client.Send(myemail, toAddress, subject, code.ToString());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Email Handler|| SendMail |"+e.Message);
                return false;
            }
        }
    }
}