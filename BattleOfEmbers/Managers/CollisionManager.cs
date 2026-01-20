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
        private List<IAttackable> _attackableObjects;
        private List<IDamageDealer> _attackerObjects;

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

    QuadTree<Vector2> quadTree = new Auios.QuadTree<Vector2>(800, 600);


    }
}