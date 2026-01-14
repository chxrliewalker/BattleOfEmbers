using SplashKitSDK;
namespace BattleOfEmbers.Core
{
    using BattleOfEmbers.Events;
    public interface IGameObject 
    {
        string Name { get; }
        string ShortDescription { get; }
        string FullDescription { get; }
        Point2D Position { get; set; }
        bool IsActive { get; set; }
        abstract void Update(MovementEvent @event, Vector2D direction, float deltaTime);
        Sprite GetSprite { get; }
        abstract void Draw();
    }
}