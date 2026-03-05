using System.Numerics;
using BattleOfEmbers.BehaviourInterfaces;
using BattleOfEmbers.Characters;
using BattleOfEmbers.Core;
using BattleOfEmbers.Events;
using SplashKitSDK;
using Auios.QuadTree;
using System.ComponentModel;
namespace BattleOfEmbers.Managers
{
    
    public class CollisionManager
    {
        private  _bounds;
        private List<IHurtable> _hurtableObjects;
        private List<IAttackable> _attackerObjects;

        private protected CollisionManager(List<IHurtable> attackables, List<IAttackable> damageDealers)
        {
            _hurtableObjects = attackables; _attackerObjects = damageDealers;
        }

        public CollisionManager Instance(List<IHurtable> hurtables, List<IAttackable> attackables)
        {
            return new CollisionManager(hurtables, attackables);   
        }
        public void CheckCollision(ICharacter obj, ICharacter objA)
        {
            if (SplashKit.SpriteCollision(obj.GetSprite, objA.GetSprite))
            {
                PublishCollision(obj, objA);
            }
        }

        public void PublishCollision(ICharacter obj, ICharacter objA)
        {
            EventBus.Instance.Publish(new BaseCollisionInfo(obj, objA));
        }


        //How in the fuck do I code a quadtree in C# 

    Auios.QuadTree.QuadTree<Vector2> quadTree = new QuadTree<Vector2>(200, 200, new IQuadTreeObjectBounds<Vector2>(new Vector2(0, 0), new Vector2(200, 200)));
    }
}