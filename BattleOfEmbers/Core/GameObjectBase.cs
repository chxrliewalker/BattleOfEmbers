using System.Numerics;
using SplashKitSDK;
namespace BattleOfEmbers.Core
{
    using BattleOfEmbers.States; 
    using BattleOfEmbers.Events; 
    using BattleOfEmbers.Core;
    using System.Runtime.CompilerServices;

    public class GameObjectBase : IdentifiableObject, IGameObject
    {
        private ObjectStateMachine _stateMachine;
        private string _name;
        private string _description;
        private Point2D _position;
        private bool _isActive;
        private List<string> _identifiers = new List<string>();
        private string _spriteSheetLocation;
        private Sprite _objectSprite;
        private float _speedOfMovement; 

        public GameObjectBase(string name, string desc, Point2D position, bool isActive, string[] ids, string spriteSheet, string ani) : base(ids)
        {
            _name = name;
            _description = desc;
            _position = position;
            _isActive = isActive;
            _identifiers = ids.ToList();
            _spriteSheetLocation = spriteSheet;
            _objectSprite = SplashKit.CreateSprite(_name);
        }

        public string Name => _name;
        public string ShortDescription => $"{_name}, {FirstId}";
        public string FullDescription => _description;
        public Point2D Position { get { return _position; } set { _position = value; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public Sprite GetSprite { get { return _objectSprite; } }


        public void Draw()
        {
            // initial draw logic of game obj
            SplashKit.SpriteSetX(_objectSprite, _position.X);
            SplashKit.SpriteSetY(_objectSprite, _position.Y);
            SplashKit.DrawSprite(_objectSprite);
        }
        public virtual void ApplyMovement(MovementEvent @event, float deltaTime)
        {
            if (_position.X != @event.destination.X || _position.Y != @event.destination.Y)
            {
                _position.X += @event.direction.X * _speedOfMovement * deltaTime;
                _position.Y += @event.direction.Y * _speedOfMovement * deltaTime;//x and y movement logic
                // only movement helper, animations will be done by the different individual states
            }
            else { return; }           
        }
        public virtual void Update(MovementEvent @event, Vector2D direction, float deltaTime)
        {
            _stateMachine.Update(this, deltaTime, @event);
        }

        public virtual void RequestStateChange(IObjectState newState) { }
    }
}
