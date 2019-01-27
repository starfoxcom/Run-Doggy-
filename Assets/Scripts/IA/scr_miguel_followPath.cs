using System.Collections.Generic;
using UnityEngine;

public class Scr_miguel_followPath
   : scr_state
{
    private scr_enemy_miguel m_miguel;

    private scr_gameMaster m_master;

    public Scr_miguel_followPath(scr_enemy_miguel _miguel)
        : base((int)MIGUEL_STATE.Moving)
    {
        m_miguel = _miguel;

        m_master = scr_gameMaster.GetSingleton();
        return;
    }

    public override void
    OnEnter()
    {
        m_miguel.m_time = 0.0f;
        return;
    }

    public override void
    OnExit()
    { }

    public override void
    Update()
    {
        if(m_master.ISPAUSE)
        { return; }

        m_miguel.m_time += Time.deltaTime;

        if(m_miguel.m_target == null)
        {
            if(m_miguel.m_path.Count != 0)
            {
                m_miguel.m_target = m_miguel.m_path.Dequeue();
            }
            else
            {
                m_miguel.m_rb.velocity = Vector3.zero;
                return;
            }
        }        

        Vector3 vectToTarget = m_miguel.m_target.POSITION - m_miguel.transform.position;
        m_miguel.m_direction = vectToTarget.normalized;
        m_miguel.m_rb.velocity = m_miguel.m_direction * Time.deltaTime * scr_enemy_miguel.m_speed;
        
        if (vectToTarget.magnitude < 0.05f)
        {
            m_miguel.m_start = m_miguel.m_target;

            if (m_miguel.m_path.Count != 0)
            {
                m_miguel.m_target = m_miguel.m_path.Dequeue();
            }
            else
            {
                m_miguel.m_fsm.SetState((int)MIGUEL_STATE.CalculatePath);
                return;
            }

            if (m_miguel.m_time >= scr_enemy_miguel.SEARCH_TIME_LAPSE)
            {
                m_miguel.m_fsm.SetState((int)MIGUEL_STATE.CalculatePath);
                return;
            }
        }
        return;
    }
}