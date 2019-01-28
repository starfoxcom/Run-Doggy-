using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class CustomModule<T>
        where T : new()
{
    static protected T _singleton = default(T);

    public abstract void
    Prepare();

    public abstract void
    SetFree();

    public static T
    GetSingleton()
    {
        if (_singleton == null)
        {
            _singleton = new T();
        }

        return _singleton;
    }

    public static bool
    IsCreated
    {
        get { return (_singleton != null); }
    }
}