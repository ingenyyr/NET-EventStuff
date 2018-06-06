using System;
using System.Collections;
using System.Collections.Generic;
using Events.DataClasses;

namespace Events
{
    /// <summary>
    /// The implementation is basicly copied from CLR via C# book
    /// </summary>
    public class EventSet
    {
        // eventCollection
        private Dictionary<EventIdentifier, Delegate> events = new Dictionary<EventIdentifier, Delegate>();

        public void AddEvent(EventIdentifier eventIdentifier, Delegate handler)
        {
            lock (events)
            {
                Delegate oldHandler;

                events.TryGetValue(eventIdentifier, out oldHandler);

                events[eventIdentifier] = Delegate.Combine(handler, oldHandler);
            }
        }

        public void RemoveEvent(EventIdentifier eventIdentifier, Delegate handler)
        {
            lock (events)
            {
                Delegate oldHandler;

                if (events.TryGetValue(eventIdentifier, out oldHandler));
                {
                    var newHandler = Delegate.Remove(oldHandler, handler);

                    if (newHandler != null)
                    {
                        events[eventIdentifier] = newHandler;
                    }
                    else
                    {
                        events.Remove(eventIdentifier);
                    }
                }
                
            }
        }

        public void RaiseEvent(EventIdentifier eventIdentifier, object sender, EventArgs args)
        {
            Delegate handler;
            lock (events)
            {
                events.TryGetValue(eventIdentifier, out handler);
            }

            handler?.DynamicInvoke(sender, args);
        }
    }
}