using System.Reflection.Metadata;
using BattleOfEmbers.Characters;
using BattleOfEmbers.Core;
namespace BattleOfEmbers.BehaviourInterfaces 
{
    public interface IUsable
    {
        void Use(GameObjectBase gameObject);
    }

    public interface IEquippable
    {
        void Equip(GameObjectBase gameObject); 
        void Unequip(GameObjectBase gameObject);
    }

    public interface IDamageDealer
    {
        float Damage {get; set;}
    }

    public interface IAttackable
    {
        void Attack(ICharacter character);
    }

    
}