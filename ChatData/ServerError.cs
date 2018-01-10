using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// Struct Containing Error Message And Is The Error Critical
    /// </summary>
    [Serializable]
    public struct Error
    {
        public string Message { get; private set; }
        public bool Critical { get; private set; }

        public Error(string message,bool critical)
        {
            Message = message;
            Critical = critical;
        }
    }
}
