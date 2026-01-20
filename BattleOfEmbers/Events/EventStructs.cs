using System.Drawing;
using SplashKitSDK;
namespace BattleOfEmbers.Events
{
    using BattleOfEmbers.Characters;
    using BattleOfEmbers.Core;
    public interface IBaseCollision
    {
        ICharacter FirstObject { get; }
        ICharacter SecondObject { get; }
    }
    public struct BaseCollisionInfo : IBaseCollision
    {
        
        public ICharacter FirstObject { get; init; }
        public ICharacter SecondObject { get; init; }

        public BaseCollisionInfo(ICharacter ch1, ICharacter ch2)
        {
            FirstObject = ch1; SecondObject = ch2;
        }
    }
    public struct HitCollision : IBaseCollision
    {
        public BaseCollisionInfo Base; // embed base within extended struct
        // keeps the base within a 'box' keeping base data together
        public int HitPower { get; init; }
        public IGameObject Initiator => Base.Initiator;
        public IGameObject Receiver => Base.Receiver;
    }



    // MOVEMENT STRUCT(S)
    public interface IMovementStruct
    {
        Point2D origin { get; }
        Point2D current { get; set; }
        Point2D destination { get; }
        Vector2D direction {get; init;}
    }

    public struct MovementEvent : IMovementStruct
    {
        public Point2D origin { get; init; }
        public Point2D current { get; set; }
        public Point2D destination { get; init; }
        public Vector2D direction { get; init; }
    }
    public interface IInventoryStruct
    {
        bool Added { get; }
    }
}


// Collision Structs ------------------------


public interface IBaseCollision
