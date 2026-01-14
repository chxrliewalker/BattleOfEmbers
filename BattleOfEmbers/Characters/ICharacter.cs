using System.Numerics;
using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace BattleOfEmbers.Characters
{
    using BattleOfEmbers.States;
    public interface ICharacter
    {
        public abstract void Move();
        public abstract void Attack();
        public void Roll();
        public void UseItem();
        public Sprite GetSprite { get; }
        public string AnimationName { get; set; }
        public void RequestStateChange(IObjectState state);
        public Vector2D Velocity { get; set; }
        public Item CurrentEquippedWeapon { get; set; }
    }
}