using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class src_aStarBuffer
{
    private List<src_aStarNode> m_nodeList;

    public src_aStarBuffer()
    {
        m_nodeList = new List<src_aStarNode>();
        return;
    }

    public void
    AddNode(src_aStarNode _node)
    {
        foreach (src_aStarNode node in m_nodeList)
        {
            if(node.m_node == _node.m_node)
            {
                if(node.m_h > _node.m_h)
                {
                    m_nodeList.Remove(node);
                    m_nodeList.Add(_node);
                    return;
                }

                return;
            }
        }

        m_nodeList.Add(_node);
        return;
    }

    public bool
    IsEmpty()
    {
        return m_nodeList.Count == 0;
    }

    public src_aStarNode
    GetNode()
    {
        // Security Check.
        if (m_nodeList.Count == 0)
        {
            return null;
        }

        src_aStarNode m_best = null;

        // Get Best.
        foreach (src_aStarNode node in m_nodeList)
        {
            if (m_best == null)
            {
                m_best = node;
                continue;
            }

            if (node.m_h < m_best.m_h)
            {
                m_best = node;
            }
        }

        // Remove Best from list.
        m_nodeList.Remove(m_best);

        // Give Best.
        return m_best;
    }
}

