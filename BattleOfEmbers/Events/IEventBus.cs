using System.Runtime.CompilerServices;

namespace BattleOfEmbers.Events
{
    public interface IEventBus
    {
        public abstract void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : struct;
        //action is a pointer to method 'handler' that will be called by the eventbus
        // ex: in player class: EventBus.Instance.Subscribe<PlayerHitEvent>(HandlePlayerHitEvent)
        public abstract void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : struct;
        public abstract void Publish<TEvent>(TEvent @event) where TEvent : struct;
    }
}