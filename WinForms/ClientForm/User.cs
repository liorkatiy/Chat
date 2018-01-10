using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chat
{
   [Serializable]
   public class User
    {
        public string Name { get; private set; }
       public Color Mycolor { get; set; }
        public User(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
