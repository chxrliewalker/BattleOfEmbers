using SplashKitSDK;

namespace BattleOfEmbers.States
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events; 
    public class DefendObjectState : IObjectState
    {
        private float _defendDuaration;
        public DefendObjectState()
        {
            _defendDuaration = 0;
        }

        public void Enter(GameObjectBase gameObject)
        {
            gameObject.AnimationName = "defend";
            SplashKit.SpriteStartAnimation(gameObject.GetSprite, gameObject.AnimationName);
        }

        public void Update(GameObjectBase character, float deltaTime, MovementEvent @event)
        {
            SplashKit.UpdateSpriteAnimation(character.GetSprite);
            _defendDuaration += deltaTime;
        }

        public void Exit(GameObjectBase gameObject) { }
    }
}