using System.Reflection.Metadata;
using BattleOfEmbers.Characters;
using BattleOfEmbers.Core;
using SplashKitSDK;
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
}