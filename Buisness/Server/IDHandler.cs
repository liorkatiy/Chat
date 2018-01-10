using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    /// <summary>
    /// Simple ID Handler To Create Unique ID For Each User
    /// </summary>
    class IDHandler
    {
        Queue<int> idQ;

        /// <summary>
        /// Instantiate New IDHandler With Amount Of IDs
        /// </summary>
        /// <param name="amount">The Amount Of Diffrent ID</param>
        public IDHandler(int amount)
        {
            idQ = new Queue<int>(amount);
            for (int i = 0; i < amount; i++)
            {
                idQ.Enqueue(i);
            }
        }

        /// <summary>
        /// Dequeue ID
        /// </summary>
        /// <returns>Unique ID</returns>
        public int GiveID()
        {
            lock (idQ)
                return idQ.Dequeue();
        }

        /// <summary>
        /// Enqueue ID From NetUser
        /// </summary>
        /// <param name="u"></param>
        public void TakeID(NetUser u)
        {
            lock (idQ)
                idQ.Enqueue(u.ID);
        }
    }
}
