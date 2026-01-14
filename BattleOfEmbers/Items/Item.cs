namespace BattleOfEmbers.Items {
    using System.Reflection.Metadata;
    using System.Runtime.CompilerServices;
    using BattleOfEmbers.Core;
    using SplashKitSDK;

    //public abstract class Item : GameObjectBase,
    //{
    //    private int _uses;
    //    private float _strength;
    //    private float _k;
    //    public Item(string name, string desc, Point2D pos, bool isActive, string[] ids, string spriteSheet, string ani) : base(name, desc, pos, isActive, ids, spriteSheet, ani)
    //    {
    //        
    //    }
//
    //    public void Use()
    //    {
    //        
    //    }
    //}


    public abstract class Item : GameObject
    {
        private float _weight;
        public Item(string name, string desc, string[] ids, float weight) : base(name, desc, ids)
        {
            _weight = weight;   
        }

        public float Weight => _weight;
    }
}