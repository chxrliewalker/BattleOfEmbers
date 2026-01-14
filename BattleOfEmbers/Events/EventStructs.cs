using System.Drawing;
using SplashKitSDK;
namespace BattleOfEmbers.Events
{
    using BattleOfEmbers.Core;
    public interface IBaseCollision
    {
        IGameObject Initiator { get; }
        IGameObject Receiver { get; }
    }
    public struct BaseCollisionInfo : IBaseCollision
    {
        
        public IGameObject Initiator { get; init; }
        public IGameObject Receiver { get; init; }
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