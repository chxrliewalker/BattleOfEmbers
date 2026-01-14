using SplashKitSDK;

namespace BattleOfEmbers.States
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    using BattleOfEmbers.Events; 
    public class StunnedObjectState : IObjectState
    {
        private float _stunDuration;
        private float _elapsedTime;

        public StunnedObjectState()
        {
            _stunDuration = 0;
            _elapsedTime = 0f;  
        }
        public void Enter(GameObjectBase character, float stunDuration)
        {
            _stunDuration = stunDuration;
            character.AnimationName = "stunned"; // setting the animation name linked to the char
            SplashKit.SpriteStartAnimation(character.GetSprite, character.AnimationName);// then is used here to play animation
            // "stunned" for ex.
        }

        //public void Update(ICharacter character, float deltaTime)
        //{
        //    SplashKit.UpdateSpriteAnimation(character.GetSprite);
        //    _elapsedTime += deltaTime;
        //    if (_elapsedTime >= _stunDuration)
        //    {
        //        character.RequestStateChange(new IdleCharacterState()); // defers logic to change state
        //        // to a RequestStateChange method in the IChar --> character
        //        // this then calls it's field of the CharStateMachine to change the state finally
        //    }
        //    // need to update non-movement/ attacking logic here
        //}

        public void Update(GameObjectBase gameObject, float deltaTime, MovementEvent @event)
        {
            _elapsedTime += deltaTime;
            if (_elapsedTime >= _stunDuration) {
                SplashKit.UpdateSpriteAnimation(gameObject.GetSprite);
                gameObject.RequestStateChange(new IdleObjectState());
                Exit(gameObject);
            } else
            {
                SplashKit.UpdateSpriteAnimation(gameObject.GetSprite);
            }
        }

        public void Exit(GameObjectBase gameObject)
        {
            _stunDuration = 0;
            _elapsedTime = 0;
        }

        public void Enter(GameObjectBase character)
        {
            throw new NotImplementedException();
        }
    }
}