using System.Numerics;
using BattleOfEmbers.BehaviourInterfaces;
using BattleOfEmbers.Characters;
using BattleOfEmbers.Core;
using BattleOfEmbers.Events;
using SplashKitSDK;
using Auios.QuadTree;
namespace BattleOfEmbers.Managers
{
    
    public class CollisionManager
    {
        // this class needs to be able to manage collision. It will have seperate methods to check for, publish and optimise collision detection
        // COLLISION OPTIMISATION METHOD:
        // needs to be able to produce a quadtree of attacker and hurtable objects
        // be able to determine after x amount of iterations if there could possibly be a collision
        // be able to return couples of hurtable and attacker objects that have met that quad threshold
        private  List<int> _bounds;
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


        public /*List<(IHurtable, IAttackable)>*/ int Quadtree()
        {
                                    
            return 0;
        }
        //How in the fuck do I code a quadtree in C# 

        Auios.QuadTree.QuadTree<Vector2> quadTree = new QuadTree<Vector2>(200, 200, new IQuadTreeObjectBounds<Vector2>(new Vector2(0, 0), new Vector2(200, 200)));



    }
}