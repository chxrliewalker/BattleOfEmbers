using System.Collections.Concurrent;
using BattleOfEmbers.BehaviourInterfaces;
using SplashKitSDK;


class QuadTree
{
    private int _interactables;
    private QuadTree[] _childQuads;
    private float _x;
    private float _y;
    private float _width;
    private float _height;
    static private readonly int _thresholdMinimum = 2;

    //static QuadTree()  static ctor. belongs to QuadTree itself. Runs exactly once before any instances of a quadtree is created 
    //{
    //    _thresholdMinimum = 2;
    //}
    public QuadTree(List<IInteractable, float x, float y, float width, float height)
    {
        _interactables = interactables;
        _x = x; _y = y;
        _width = width; _height = height;
    }

    public void Partition()
    {
        _childQuads = new QuadTree[] { // always new since a single quad can only have one segmentation
            new QuadTree(_hurtableObjects, _attackableObjects, _x, _y, _width/2, _height/2), // NW
            new QuadTree(_hurtableObjects, _attackableObjects, _x + _width/2, _y, _width/2, _height/2), // NE
            new QuadTree(_hurtableObjects, _attackableObjects, _x, _y + _height/2, _width/2, _height/2), // SW
            new QuadTree(_hurtableObjects, _attackableObjects, _x + _width/2, _y + _height/2, _width/2, _height/2), // SE
            };
        for (int i = 0; i < 4; i++)
        {
            foreach (IHurtable hObject in _hurtableObjects)
            {
                if (FallsInQuad(_childQuads[i], hObject))
                {
                    _childQuads[i]._hurtableObjects.Append(hObject);
                }
            
            }
            foreach (IAttackable aObject in _attackableObjects)
            {
                if (FallsInQuad(_childQuads[i], aObject))
                {
                    _childQuads[i]._attackableObjects.Append(aObject);
                }
            }
        }
        for (int i = 0; i < 4; i++) 
        { 
            if  (_childQuads[i].HurtableObjects + _childQuads[i].AttackableObjects < 3)
            {
                
            }
        }




        //rewrite logic for a more general "Interactable Object"


    }

    public void Partition()
    {
        
    }

    private bool FallsInQuad(QuadTree quad, IInteractable obj)
    {
        if (obj.Position.X >= quad._x && obj.Position.X <= quad._x + quad._width
            && obj.Position.Y >= quad._y && obj.Position.Y <= quad._y + quad._height)
        {
            return true;
        } else {return false;}
    }

    public int HurtableObjects
    {
        get 
        {
            int i = 0;
            foreach (IHurtable hObject in _hurtableObjects)
            {
                i++;
            } return i;
        }   
    }
    public int AttackableObjects
    {
        get 
        {
            int i = 0;
            foreach (IAttackable aObject in _attackableObjects)
            {
                i++;
            } return i;
        }   
    }


}