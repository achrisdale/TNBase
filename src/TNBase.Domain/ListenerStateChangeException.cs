using System;

namespace TNBase.Domain
{
    public class ListenerStateChangeException : Exception
    {
        public ListenerStateChangeException()
        { }

        public ListenerStateChangeException(string message) : base(message)
        { }
    }
}
