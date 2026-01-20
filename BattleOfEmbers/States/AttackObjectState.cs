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
            character.Attack(); // this tells the object that is attackign to attack with its currently
            // equipped item/ weapon
        }
        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            // need to rewrite:
            //  - Check for collision
            //  - Be able to return a struct that is interpreted by the state machine
            //  and is published to the event bus if necessary.


            // ------------------ TO LOOK AT: MANAGER FOR COLLISIONS ------------------
            // - able to decouple an attacking state from all other objects within the game
            // - more efficient: O(n^2) = checking for all objects in each update method..
            // O(log(n)) closer to with manager
            // - Scalable with increased number of objects within a game
        }
        public void Exit(GameObjectBase character)
        {
            throw new NotImplementedException();
        }
    }
}