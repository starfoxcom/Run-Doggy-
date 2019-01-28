using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class scr_fsm
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////
    
    private List<scr_state> m_stateList;

    private scr_state m_activeState;

    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////
    
    public void
    Init()
    {
        m_stateList = new List<scr_state>();
        m_activeState = null;

        return;
    }

    public void
    AddState(scr_state _state)
    {
        m_stateList.Add(_state);
        return;
    }

    public void
    SetState(int _id)
    {
        foreach(scr_state state in m_stateList)
        {
            if(state.ID == _id)
            {
                if(m_activeState != null)
                {
                    m_activeState.OnExit();
                }

                m_activeState = state;
                m_activeState.OnEnter();

                return;
            }
        }
        return;
    }

    public void
    Update()
    {
        if(m_activeState != null)
        {
            m_activeState.Update();
        }
        return;
    }
}
