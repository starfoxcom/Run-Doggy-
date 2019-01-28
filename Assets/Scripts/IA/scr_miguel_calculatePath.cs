using System.Collections.Generic;
using UnityEngine;

 public class Scr_miguel_calculatePath
    : scr_state
 {
    private scr_enemy_miguel m_miguel;

    public Scr_miguel_calculatePath(scr_enemy_miguel _miguel) 
        : base((int)MIGUEL_STATE.CalculatePath)
    {
        m_miguel = _miguel;
        return;
    }

    public override void 
    OnEnter()
    {
        m_miguel.m_path.Clear();

        scr_aStarClosed closed = new scr_aStarClosed();
        src_aStarBuffer open = new src_aStarBuffer();

        src_aStarNode starNode;

        // Start AStar Node.
        starNode = new src_aStarNode(m_miguel.m_start, null, 0.0f);
        open.AddNode(starNode);

        // Get Target.
        Vector3 targetPosition = m_miguel.m_dog.TARGET.POSITION;

        while (!open.IsEmpty())
        {

            // Get Best Node.
            src_aStarNode e = open.GetNode();

            if(e.m_node == m_miguel.m_dog.TARGET)
            {
                m_miguel.m_path = closed.Resolve(e);
                return;
            }
                        
            if(e.m_node.UP != null)
            {
                if(e.m_node.UP.NODETYPE != NODE_TYPE.kBlock)
                {  
                    if(!closed.Contains(e.m_node.UP))
                    {
                        src_aStarNode newNode
                        = new src_aStarNode(e.m_node.UP,
                                            e.m_node,
                                            e.m_h + (e.m_node.UP.POSITION - targetPosition).magnitude);
                        open.AddNode(newNode);
                    }                    
                }
            }

            if (e.m_node.DOWN != null)
            {
                if (e.m_node.DOWN.NODETYPE != NODE_TYPE.kBlock)
                {
                    if (!closed.Contains(e.m_node.DOWN))
                    {
                        src_aStarNode newNode
                        = new src_aStarNode(e.m_node.DOWN,
                                            e.m_node,
                                            e.m_h + (e.m_node.DOWN.POSITION - targetPosition).magnitude);
                        open.AddNode(newNode);
                    }
                }
            }

            if (e.m_node.RIGHT != null)
            {
                if (e.m_node.RIGHT.NODETYPE != NODE_TYPE.kBlock)
                {
                    if (!closed.Contains(e.m_node.RIGHT))
                    {
                        src_aStarNode newNode
                        = new src_aStarNode(e.m_node.RIGHT,
                                            e.m_node,
                                            e.m_h + (e.m_node.RIGHT.POSITION - targetPosition).magnitude);
                        open.AddNode(newNode);
                    }
                }
            }

            if (e.m_node.LEFT != null)
            {
                if (e.m_node.LEFT.NODETYPE != NODE_TYPE.kBlock)
                {
                    if (!closed.Contains(e.m_node.LEFT))
                    {
                        src_aStarNode newNode
                        = new src_aStarNode(e.m_node.LEFT,
                                            e.m_node,
                                            e.m_h + (e.m_node.LEFT.POSITION - targetPosition).magnitude);
                        open.AddNode(newNode);
                    }
                }
            }

            closed.Add(e);
        }

        m_miguel.m_time = 0.0f;     
        return;
    }

    public override void 
    OnExit()
    {
        if(m_miguel.m_path.Count != 0)
        {
            m_miguel.m_target = m_miguel.m_path.Dequeue();
        }        
    }

    public override void 
    Update()
    {
        m_miguel.m_fsm.SetState((int)MIGUEL_STATE.Moving);
        return;
    }
}

