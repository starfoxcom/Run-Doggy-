using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class scr_state
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////
    
    private int m_id;

    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////
    
    public scr_state(int _id)
    {
        m_id = _id;
        return;
    }

    public virtual void
    OnEnter()
    { }

    public virtual void
    Update()
    { }

    public virtual void
    OnExit()
    { }

    public int ID
    {
        get { return m_id; }
    }
}

