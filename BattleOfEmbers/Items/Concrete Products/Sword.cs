using BattleOfEmbers.BehaviourInterfaces;
using BattleOfEmbers.Characters;
using BattleOfEmbers.States;

namespace BattleOfEmbers.Items.ConcreteProducts
{
    public class Sword : Item, IEquippable, IDamageDealer, IAttackable
    {
        private float _damage;
        
        public Sword(string name, string desc, string[] ids, float damage, float weight) : base(name, desc, ids, weight)
        {
            _damage = damage;
        }

        public float Damage
        {
            get { return _damage;}
            set {_damage = value;}
        }

        public void Attack(ICharacter character)
        {
            character.RequestStateChange(new AttackObjectState());
        }
    }
}