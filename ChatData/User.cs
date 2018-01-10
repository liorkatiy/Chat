using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;

namespace ChatData
{
    /// <summary>
    /// User Struct Containing Only string Name int ID
    /// </summary>
    [Serializable]
    public struct User
    {
        public string Name { get; private set; }
        public int ID { get; private set; }

        public User(string name, int id)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator int(User u)
        {
            return u.ID;
        }

        public static implicit operator string(User u)
        {
            return u.Name;
        }
    }
}