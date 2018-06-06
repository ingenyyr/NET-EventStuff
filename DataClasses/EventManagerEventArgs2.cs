using System;

namespace Events.DataClasses
{
    public class EventManagerEventArgs2 : EventArgs
    {
        public EventManagerEventArgs2(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}