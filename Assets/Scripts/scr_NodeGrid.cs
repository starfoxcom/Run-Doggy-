using UnityEngine;

public class scr_NodeGrid
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Number of columns
    /// </summary>
    private int numCols;

    /// <summary>
    /// Number of Rows
    /// </summary>
    private int numRows;

    /// <summary>
    /// Grid of Nodes.
    /// </summary>
    private scr_Node[,] m_nodeGrid;

    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////

    // Initializate the node grid.
    public void 
    Init(int _numCols, int _numRows)
    {
        numCols = _numCols;
        numRows = _numRows;

        m_nodeGrid = new scr_Node[numRows,numCols];

        for (int row = 0; row < numRows; ++row)
        {
            for (int col = 0; col < numCols; ++col)
            {
                m_nodeGrid[row, col] = new scr_Node();
            }
        }

                //////////////////////////////////////////////////////////////////////////
                // Set Connections                                                      //
                //////////////////////////////////////////////////////////////////////////
                for (int row = 0; row < numRows; ++row )
        {
            for (int col = 0; col < numCols; ++col)
            {
                
                // Add Up Node.
                if(row > 0)
                {
                    m_nodeGrid[row, col].SetUp(m_nodeGrid[row - 1, col]);
                }

                // Add Right Node.
                if(col < (numCols - 1))
                {
                    m_nodeGrid[row, col].SetRight(m_nodeGrid[row, (col + 1)]);
                }

                // Add Down Node.
                if(row < (numRows - 1))
                {
                    m_nodeGrid[row, col].SetDown(m_nodeGrid[row + 1, col]);
                }

                // Add Left Node.
                if(col > 0)
                {
                    m_nodeGrid[row, col].SetLeft(m_nodeGrid[row, col - 1]);
                }
            }
        }
    }

    /// <summary>
    /// Get a node from the node grid.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public scr_Node 
    GetNode(int row, int col)
    {
        if( m_nodeGrid == null
            || row >= numRows 
            || col >= numCols
            || row < 0
            || col < 0)
        {
            return null;
        }

        return m_nodeGrid[row, col];
    }

    public int
    NUMROWS
    {
        get
        {
            return numRows;
        }
    }

    public int
    NUMCOLS
    {
        get
        {
            return numCols;
        }
    }


    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////

    private void 
    Start()
    { }
}
