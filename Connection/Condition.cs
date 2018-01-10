using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    /// <summary>
    /// Struct That Have Status And Action
    /// </summary>
    /// <typeparam name="S">The Enum</typeparam>
    struct Condition<S>
        where S : struct
    {
        internal S Status { get; private set; }
        internal Action<object, Connection<S>> Action { get; private set; }

        internal Condition(S status, Action<object, Connection<S>> action)
        {
            Status = status;
            Action = action;
        }
    }
}
