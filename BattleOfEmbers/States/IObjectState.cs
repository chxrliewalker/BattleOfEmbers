namespace BattleOfEmbers.States
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events;
    public interface IObjectState
    {
        void Enter(GameObjectBase character);
        void Exit(GameObjectBase character);
        void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event);
    }
}