using SplashKitSDK;
namespace BattleOfEmbers.Characters
{
    using BattleOfEmbers.Core;
    using BattleOfEmbers.States;
    using BattleOfEmbers.Events;
    using BattleOfEmbers.Items;
    public class PlayableCharacter : GameObjectBase, ICharacter
    {
        private float _health;
        private float _attackPower;
        private float _armour;
        private List<Item> _items;
        private int _rage;
        private ObjectStateMachine _stateMachine;
        private ICharacterAttackStrategy _attackStrategy;
        private Item _currentWeapon;
        private string _currentAnimationState;

        public PlayableCharacter(float health, float attackPower, float armour, string name, string desc, Point2D position, bool isActive, string[] ids, string spriteSheet, string ani)
        : base(name, desc, position, isActive, ids, spriteSheet, ani)
        {
            _health = health;
            _attackPower = attackPower;
            _armour = armour;
            _rage = 0;
            _stateMachine = new ObjectStateMachine(this);
            _stateMachine.InitialiseState(new IdleCharacterState(), this);
        }

        public string AnimationName {get { return _currentAnimationState; } set { _currentAnimationState = value; }}

        public override void Update(MovementEvent @event, Vector2D direction, float deltaTime)
        {
            base.Update(@event, direction, deltaTime);
            _stateMachine.Update(this, deltaTime);
        }
        public override void RequestStateChange(IObjectState newState)
        {
            _stateMachine.ChangeStates(this, newState);
        }
        public void Attack()
        {
            _currentWeapon.Attack();
        }

    }
}