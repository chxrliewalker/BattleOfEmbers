using SplashKitSDK;

namespace BattleOfEmbers.States
{
    using System.Transactions;
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events;

    public class AttackObjectState : IObjectState
    {
        private bool _damageApplied;
        public AttackObjectState()
        {
            _damageApplied = false;
        }

        public void Enter(ICharacter character)
        {
            character.AnimationName = "attack";
            SplashKit.SpriteStartAnimation(character.GetSprite, character.AnimationName);
            _damageApplied = false;
            Attack(character);
        }
        public void Attack(ICharacter character)
        {
            character.Attack();
        }
        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            throw new NotImplementedException();
        }
        public void Exit(GameObjectBase character)
        {
            throw new NotImplementedException();
        }
    }
}