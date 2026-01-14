using System.Diagnostics.Contracts;
using SplashKitSDK;

namespace BattleOfEmbers.States
{
    using System.Runtime.CompilerServices;
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events; 
    public class ParryObjectState : IObjectState 
    {
        private float _parryWindow;
        private float _elapsedTime;
        private bool _parrySuccessful;

        public ParryObjectState(float parryWindow)
        {
            _parryWindow = parryWindow;
            _elapsedTime = 0f;
            _parrySuccessful = false;
        }
        public void Enter(GameObjectBase gameObject)
        {
            gameObject.AnimationName = "parry";
            SplashKit.SpriteStartAnimation(gameObject.GetSprite, gameObject.AnimationName);
            _parrySuccessful = false;
        }
        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event) 
        {
            SplashKit.UpdateSpriteAnimation(gameObject.GetSprite);
            _elapsedTime += deltaTime;
            // need to add implementation here if wanting to use it completely
        }

        public void Exit(GameObjectBase gameObject) {}
    }
}