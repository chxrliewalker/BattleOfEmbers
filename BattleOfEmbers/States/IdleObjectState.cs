using System.Transactions;
using SplashKitSDK;

namespace BattleOfEmbers.States
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events;
    public class IdleObjectState : IObjectState
    {
        public void Enter(GameObjectBase gameObject)
        {
            gameObject.AnimationName = "idle";
            SplashKit.SpriteStartAnimation(gameObject.GetSprite, gameObject.AnimationName);
        }

        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            SplashKit.UpdateSpriteAnimation(gameObject.GetSprite);
        }

        public void Exit(GameObjectBase gameObject)
        {
            
        }
    }
}