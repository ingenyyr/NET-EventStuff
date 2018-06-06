using System;

namespace Events.DataClasses
{
    public class EventManagerEventArgs : EventArgs
    {
        public EventManagerEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}