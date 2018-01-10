using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// Base Class To Verify Clients
    /// </summary>
    [Serializable]
    public abstract class VerifyClient
    {
        bool Success;
        string Error;

        public VerifyClient()
        {
            Success = true;
        }

        public VerifyClient(string error)
        {
            Error = error;
            Success = false;
        }

        public static implicit operator bool(VerifyClient entry)
        {
            return entry.Success;
        }

        public static implicit operator string(VerifyClient entry)
        {
            return entry.Error;
        }
    }

    /// <summary>
    /// Derived From VerifyClient Verify The Login Process
    /// </summary>
    [Serializable]
    public class VerifyClientLogin : VerifyClient
    {
        public User[] Users { get; private set; }

        public VerifyClientLogin(User[] users) : base()
        {
            Users = users;
        }

        public VerifyClientLogin(string error) : base(error) { }
    }

    /// <summary>
    /// Derived From VerifyClient Verify The Register Process
    /// </summary>
    [Serializable]
    public class VerifyClientRegister : VerifyClient
    {
        public bool MailVerificationNeeded { get; private set; }

        public VerifyClientRegister(bool mailNeeded) : base()
        {
            MailVerificationNeeded = mailNeeded;
        }

        public VerifyClientRegister(string error):base(error) { }     
    }
}
