using System.Collections.Concurrent;
using BattleOfEmbers.BehaviourInterfaces;
using SplashKitSDK;

class QuadTree
{
    private List<IHurtable> _hurtableObjects;
    private List<IAttackable> _attackableObjects;
    private QuadTree[] _childQuads;
    private float _x;
    private float _y;
    private float _width;
    private float _height;
    static private readonly int _thresholdMinimum = 2;

    static QuadTree() // static ctor. belongs to QuadTree itself. Runs exactly once before any instances of a quadtree is created 
    {
        _thresholdMinimum = 2;
    }
    public QuadTree(List<IHurtable> hurtables, List<IAttackable> attackables, float x, float y, float width, float height)
    {
        _hurtableObjects = hurtables; _attackableObjects = attackables;
        _x = x; _y = y;
        _width = width; _height = height;
        _childQuads = null;
    }

    public void Partition(QuadTree quad)
    {
        _childQuads = new QuadTree[] {
            new QuadTree(_hurtableObjects, _attackableObjects, _x, _y, _width/2, _height/2), // NW
            new QuadTree(_hurtableObjects, _attackableObjects, _x + _width/2, _y, _width/2, _height/2), // NE
            new QuadTree(_hurtableObjects, _attackableObjects, _x, _y + _height/2, _width/2, _height/2), // SW
            new QuadTree(_hurtableObjects, _attackableObjects, _x + _width/2, _y + _height/2, _width/2, _height/2), // SE
            };
    }


}