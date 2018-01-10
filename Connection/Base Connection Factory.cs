using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Base Abstract Class For Connection Factory
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public abstract class BaseConnectionFactory<S> where S : struct
    {
        List<Condition<S>> conditionList;

        protected BaseConnectionFactory()
        {
            conditionList = new List<Condition<S>>();
        }

        /// <summary>
        /// Add Status And Action To The Connection Dictionary
        /// </summary>
        /// <param name="con">The Connection To Initialize</param>
        internal void InitializeConnection(Connection<S> con)
        {
            lock (conditionList)
            {
                for (int i = 0; i < conditionList.Count; i++)
                {
                    con.AddCondition(conditionList[i]);
                }
            }
        }

        /// <summary>
        /// Add New Condition To The Condition List
        /// </summary>
        /// <param name="status">The Enum</param>
        /// <param name="action"></param>
        internal void Add(S status, Action<object,Connection<S>> action)
        {
            conditionList.Add(new Condition<S>(status, action));
        }

        /// <summary>
        /// Add New Status Action
        /// </summary>
        /// <param name="status">The Enum</param>
        /// <param name="action">Void That Take No Parameters</param>
        public void Add(S status, Action action)
        {
            Add(status, (o, c) => action());
        }

        /// <summary>
        /// Add New Status Action
        /// </summary>
        /// <typeparam name="O">The Action Parameter</typeparam>
        /// <param name="status">The Enum</param>
        /// <param name="action">Action That Take Generic Parameter</param>
        public void Add<O>(S status, Action<O> action)
        {
            Add(status, (o, c) => action((O)o));
        }
    }
}
