using System.Collections;
using System.Collections.Generic;

public class Pool<T>
{
    public delegate T FactoryMethod();
    public delegate void ActivateOrDesactivate(T o);

    private FactoryMethod _factoryMethod;
    private ActivateOrDesactivate _activate;
    private ActivateOrDesactivate _desactivate;
    private List<T> _objects;
    private bool _isDynamic;

    public Pool(FactoryMethod f, ActivateOrDesactivate activate, ActivateOrDesactivate desactivate, int startAmmount = 0, bool isDynamic = true)
    {
        _isDynamic = isDynamic;
        _factoryMethod = f;
        _objects = new List<T>();
        _activate = activate;
        _desactivate = desactivate;
        for (int i = startAmmount - 1; i >= 0; i--)
        {
            var o = _factoryMethod();
            desactivate(o);
            _objects.Add(o);
        }
    }

    public T GetObject()
    {
        T result;
        if (_objects.Count == 0)
        {
            if (_isDynamic)
                result = _factoryMethod();
            else
                return default(T);
        }
        else
        {
            result = _objects[0];
            _objects.Remove(result);
        }
        _activate(result);
        return result;
    }

    public void ReturnObject(T o)
    {
        _desactivate(o);
        _objects.Add(o);
    }
}
