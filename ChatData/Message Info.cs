using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData
{
    /// <summary>
    /// Contains The User Name And The Color
    /// </summary>
    [Serializable]
    public struct MessageInfo
    {
        public Color Color { get; private set; }
        public string Name { get; private set; }

        public MessageInfo(Color color, string name)
        {
            Color = color;
            Name = name;
        }

        public static MessageInfo Empty
        {
            get
            {
                return new MessageInfo(Color.Empty, string.Empty);
            }
        }
    }
}
