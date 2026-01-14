using SplashKitSDK;
namespace BattleOfEmbers.Characters
{
    using BattleOfEmbers.Core;
    public class NPC : GameObjectBase
    {
        private readonly string _prompt;

        public NPC(string prompt, string name, string desc, Point2D position, bool isActive, string[] ids, string spriteSheet, string ani)
        : base(name, desc, position, isActive, ids, spriteSheet, ani)
        {
            _prompt = prompt;
        }

        public string ProvidePrompt => _prompt;
    }
}