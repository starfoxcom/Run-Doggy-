using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class scr_aStarClosed
{
    private Stack<src_aStarNode> m_starNodeList;

    public scr_aStarClosed()
    {
        m_starNodeList = new Stack<src_aStarNode>();
        return;
    }

    public void
    Add(src_aStarNode _starNode)
    {
        m_starNodeList.Push(_starNode);
        return;
    }

    public bool
    Contains(scr_Node _node)
    {
        foreach(src_aStarNode starNode in m_starNodeList)
        {
            if(starNode.m_node == _node)
            {
                return true;
            }
        }

        return false;
    }

    public Queue<scr_Node>
    Resolve(src_aStarNode _targetStarNode)
    {
        Stack<scr_Node> nodeStack = new Stack<scr_Node>();

        src_aStarNode currentStarNode = _targetStarNode;
        nodeStack.Push(_targetStarNode.m_node);

        while(m_starNodeList.Count != 0)
        {
            src_aStarNode node = m_starNodeList.Pop();

            if(node.m_pathVia == null)
            { break; }

            if(node.m_node == currentStarNode.m_pathVia)
            {
                nodeStack.Push(node.m_node);
                currentStarNode = node;
            }
        }

        Queue<scr_Node> path = new Queue<scr_Node>();
        while(nodeStack.Count != 0)
        {
            path.Enqueue(nodeStack.Pop());
        }

        return path;
    }
}
