using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    /// <summary>
    /// Interface With Generic ID
    /// </summary>
    /// <typeparam name="T">Generic ID</typeparam>
    interface IHaveID<T>
    {
        T ID { get; }
    }

    /// <summary>
    /// Thread Safe Users Dictionary Of IHaveID Interface
    /// </summary>
    internal class ThreadSafeDict<ID,IHaveID> : IEnumerable<IHaveID> where IHaveID:IHaveID<ID>
    {
        Dictionary<ID, IHaveID> iHaveIdItems;

        /// <summary>
        /// Initialize The Dictionary With Size 0
        /// </summary>
        public ThreadSafeDict() : this(0) { }

        /// <summary>
        /// Initialize The Dictionary With Given Size
        /// </summary>
        /// <param name="size"></param>
        public ThreadSafeDict(int size)
        {
            iHaveIdItems = new Dictionary<ID, IHaveID>(size);
        }

        /// <summary>
        /// Amount Of IHaveID
        /// </summary>
        public int Count { get { lock (iHaveIdItems) return iHaveIdItems.Count; } }

        /// <summary>
        /// Get IHaveID From ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IHaveID this[ID ID]
        {
            get
            {
                lock (iHaveIdItems)
                    return iHaveIdItems[ID];
            }
        }

        /// <summary>
        /// Add IHaveID Item
        /// </summary>
        /// <param name="IHaveID"></param>
        public void Add(IHaveID IHaveID)
        {
            lock (iHaveIdItems)
            {
                iHaveIdItems.Add(IHaveID.ID, IHaveID);
            }
        }

        /// <summary>
        /// Remove IHaveID Item
        /// </summary>
        /// <param name="iHaveID"></param>
        /// <returns></returns>
        public bool Remove(IHaveID iHaveID)
        {
            lock (iHaveIdItems)
            {
                return iHaveIdItems.Remove(iHaveID.ID);
            }
        }

        /// <summary>
        /// Return True If The Dictionary Contains The ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Contains(ID ID)
        {
            lock (iHaveIdItems)
                return iHaveIdItems.ContainsKey(ID);
        }

        //Enumarates The IHaveIdItems
        public IEnumerator<IHaveID> GetEnumerator()
        {
            lock (iHaveIdItems)
            {
                foreach (IHaveID item in iHaveIdItems.Values)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}