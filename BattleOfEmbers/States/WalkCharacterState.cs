using System.Diagnostics.Contracts;
using SplashKitSDK;

namespace BattleOfEmbers.States
{    
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events;

    public class WalkCharacterState : ICharacterState
    {
        private float _walkDuration;

        public WalkCharacterState()
        {
            _walkDuration = 0f;
        }

        public void Enter(GameObjectBase gameObject)
        {
            gameObject.AnimationName = "walk";
            SplashKit.SpriteStartAnimation(gameObject.GetSprite, gameObject.AnimationName);
        }

        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            _walkDuration += deltaTime;
            SplashKit.UpdateSpriteAnimation(gameObject.GetSprite);
            gameObject.ApplyMovement(@event, deltaTime);
        }

        public void Exit(GameObjectBase gameObject) {}
    } 
}