namespace BattleOfEmbers.States
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events;

    public class ObjectStateMachine // only a manager = allows changes completely without authentication that the object/character is able to do this transition
    // individual state classes will manage whether the changing of states can take place 
    {
        private IObjectState _currentGameObjectState;
        public ObjectStateMachine(GameObjectBase gameObject)
        {
            _currentGameObjectState = new IdleObjectState();
            _currentGameObjectState.Enter(gameObject);
        }

        public void ChangeStates(GameObjectBase gameObject, IObjectState newState)
        {
            _currentGameObjectState.Exit(gameObject);
            _currentGameObjectState = newState;
            _currentGameObjectState.Enter(gameObject);
        }
        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            _currentGameObjectState?.Update(gameObject, deltaTime, @event);
        }
    }
}