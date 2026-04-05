using System.Reflection.Metadata;
using BattleOfEmbers.Characters;
using BattleOfEmbers.Core;
using SplashKitSDK;
namespace BattleOfEmbers.BehaviourInterfaces 
{
    public interface IDamageDealer
    {
        float Damage {get; set;}
    }

    public interface IInteractable
    {
        Point2D Position {get;}
    }
    public interface IAttackable : IInteractable
    {
        void Attack(ICharacter character);
    }
    public interface IHurtable : IInteractable
    {
        void ReduceHealth(float damage);
    }
}