﻿using UnityEngine;

 public enum NODE_TYPE
{
    kNone,
    kStreet,
    kBlock,
    kHouse
}

 public class scr_Node
 {
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Node Type.
    /// </summary>
    private NODE_TYPE m_type;

    private Vector3 m_position;

    private scr_Node m_up;

    private scr_Node m_right;

    private scr_Node m_down;

    private scr_Node m_left;

    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////
    
    public scr_Node(Vector3 _position, NODE_TYPE _type)
    {
        m_position = _position;

        m_up =    null;
        m_right = null;
        m_down =  null;
        m_left =  null;

        m_type = _type;

        return;
    }

    public void
    SetUp(scr_Node _up)
    {
        m_up = _up;
        return;
    }

    public void
    SetLeft(scr_Node _left)
    {
        m_left = _left;
        return;
    }

    public void
    SetRight(scr_Node _right)
    {
        m_right = _right;
        return;
    }

    public void
    SetDown(scr_Node _down)
    {
        m_down = _down;
        return;
    }

    //////////////////////////////////////////////////////////////////////////
    // Setters / Getters                                                    //
    //////////////////////////////////////////////////////////////////////////     

    /// <summary>
    /// Node Type.
    /// </summary>
    NODE_TYPE
    TYPE
    {
        get
        { return m_type; }
        set
        { m_type = value; }
    }

    /// <summary>
    /// Node's position;
    /// </summary>
    Vector3 
    POSITION
    {
        get
        { return m_position; }
    }

    scr_Node
    UP
    {
        get
        { return m_up; }
    }

    scr_Node
    RIGHT
    {
        get
        { return m_right; }
    }

    scr_Node
    DOWN
    {
        get
        { return m_down; }
    }

    scr_Node
    LEFT
    {
        get
        { return m_left; }
    }

}
