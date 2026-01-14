using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace BattleOfEmbers.Events
{
    public class EventBus : IEventBus
    {
        private Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();
        private EventBus() { }// no other class is able to access the constructor
        public static EventBus Instance { get; } = new EventBus();// this is the single eventbus that all other
        //classes will interact with: singleton design principle

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : struct
        {
            if (_handlers.ContainsKey(typeof(TEvent)))
            {
                _handlers[typeof(TEvent)].Add(handler);// if _handlers has the key of  the event already:
                // add to the list of delegaters to include this object that wants to subscribe
            }
            else
            {
                _handlers.Add(typeof(TEvent), new List<Delegate> { handler });
            }
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : struct
        {
            foreach (var handler in _handlers[typeof(TEvent)])
            {
                try
                {
                    ((Action<TEvent>)handler)(@event);
                    // Try the handler of the <TEvent> action when the struct has been
                    //published to the eventbus!
                }
                catch
                {
                    throw new ArgumentException(nameof(Action<TEvent>), "EventBus can't access the method that was subscribed with");
                }
            }
        }
        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : struct
        {
            if (_handlers.ContainsKey(typeof(TEvent)))
            {
                try
                {
                    _handlers[typeof(TEvent)].Remove(handler);
                }
                catch
                {
                    throw new ArgumentException(nameof(handler), "Removing this handler was not successful on the EventBus singleton instance");
                }
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(Action<TEvent>), "Was unable to locate the type of event that the object is trying to unsubscribe from");
            }
        }
    }
}
