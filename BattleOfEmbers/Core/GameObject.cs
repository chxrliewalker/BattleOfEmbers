using System.Reflection.Metadata.Ecma335;

namespace BattleOfEmbers.Core
{
    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;
        private string[] _identifiers;

        public GameObject(string name, string desc, string[] idents) : base(idents)
        {
            _name = name;
            _description = desc;
            _identifiers = idents;
        }
        public GameObject(string name, string[] idents) : this(name, "A description doesn't exist for this object.", idents) {}

        public string Name => _name;
        public string? Description => _description;
        public string Identifiers => base.ToString();
    }
}