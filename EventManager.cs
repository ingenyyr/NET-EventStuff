using System;
using System.Threading;
using System.Windows;
using Events.DataClasses;

namespace Events
{
    public class EventManager
    {
        private EventSet _eventSet = new EventSet();

        public event EventHandler<EventManagerEventArgs> EventWithGenericParameter;

        public event EventHandler SomeEvent; // EventHandler<System.EventArgs>

        public event EventHandler<EventManagerEventArgs> EventSetEvent;

        public event EventHandler<EventManagerEventArgs2> EventSetEvent2;

        public void InvokeEventWithGenericParameter(string eventMessage)
        {
            // this is thread safe way to call it..
            EventWithGenericParameter?.Invoke(this, new EventManagerEventArgs(eventMessage)); // theoreticly there could be Read Introduction problem = JIT compiler didnt really create the temp variable. 

            // this could be the safe way?
            //var temp = Interlocked.CompareExchange(ref EventWithGenericParameter, null, null);
            //if (temp != null)
            //{
            //    temp.Invoke(this, new EventManagerEventArgs(eventMessage));
            //}
        }
    }
}