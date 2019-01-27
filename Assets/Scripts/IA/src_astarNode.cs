using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class src_aStarNode
{
    public scr_Node m_node;

    public scr_Node m_pathVia;

    public float m_h;

    public src_aStarNode()
    {
        m_node = null;
        m_pathVia = null;
        m_h = 100000.0f;

        return;
    }

    public src_aStarNode(scr_Node _node, scr_Node _pathVia, float _heuristic)
    {
        m_node = _node;
        m_pathVia = _pathVia;
        m_h = _heuristic;

        return;
    }
}

