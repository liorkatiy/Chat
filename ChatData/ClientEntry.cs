using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// User Registration Info
    /// </summary>
    [Serializable]
    public class RegisterInfo
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RegisterInfo(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    /// <summary>
    /// User Login Info
    /// </summary>
    [Serializable]
    public class LoginInfo : RegisterInfo
    {
        public string Name { get; private set; }

        public LoginInfo(string name, string email, string password) : base(email, password)
        {
            Name = name;
        }
    }
}
