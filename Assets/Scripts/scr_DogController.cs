﻿using UnityEngine;

public enum DOGPHASE
{
    None = 0,
    Moving,
    Idle
}

public enum DOGDIRECTION
{
    None = 0,
    Up,
    Right,
    Down,
    Left
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class scr_DogController 
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////

    private Vector3 m_direction;

    private scr_Node m_target;

    private DOGPHASE m_state;

    private DOGDIRECTION m_directionIndex;

    private Rigidbody2D m_rb;

    static float MIN_RADIUS_NODE_DETECTION = 0.05f;

    static float SPEED = 50.0f;
    
    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////
    
    public void
    Init(scr_Node m_node)
    {
        m_target = m_node;
        m_state = DOGPHASE.Idle;
        m_directionIndex = DOGDIRECTION.None;

        return;
    }

    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target == null)
        { return; }

        // Check Inputs.
        InputController();

        // Do Behaviour.
        switch(m_state)
        {
            case DOGPHASE.Idle:
                IdleUpdate();
                return;
            case DOGPHASE.Moving:
                MovingUpdate();
                return;
            case DOGPHASE.None:
                return;
            default:
                return;
        }
    }

    private void 
    IdleUpdate()
    {
        m_rb.velocity = Vector3.zero;        

        if(transform.position != m_target.POSITION)
        {
            transform.position = m_target.POSITION;
        }

        return;
    }

    private void
    MovingUpdate()
    {  
        // Vector to target.
        Vector3 vecToTarget = m_target.POSITION - transform.position;

        // Direction.
        m_direction = vecToTarget.normalized;        

        // Check target distance.
        float distance = vecToTarget.magnitude;
        if(distance < MIN_RADIUS_NODE_DETECTION)
        {
            NodeCollision();
        }

        // Velocity.
        m_rb.velocity = m_direction * SPEED * Time.deltaTime;

        return;
    }

    private void
    InputController()
    {
        // UP
        if(Input.GetKeyDown(KeyCode.W))
        {
            m_directionIndex = DOGDIRECTION.Up;
            m_state = DOGPHASE.Moving;
            return;
        }

        // DOWN
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_directionIndex = DOGDIRECTION.Down;
            m_state = DOGPHASE.Moving;
            return;
        }

        // RIGHT
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_directionIndex = DOGDIRECTION.Right;
            m_state = DOGPHASE.Moving;
            return;
        }

        // LEFT
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_directionIndex = DOGDIRECTION.Left;
            m_state = DOGPHASE.Moving;
            return;
        }
    }

    private void
    NodeCollision()
    {
        switch(m_directionIndex)
        {
            case DOGDIRECTION.Up:
                if (m_target.UP == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }

                if (m_target.UP.NODETYPE == NODE_TYPE.kStreet)
                {
                    m_target = m_target.UP;
                    return;
                }
                else
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }
            case DOGDIRECTION.Right:
                if (m_target.RIGHT == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }

                if (m_target.RIGHT.NODETYPE == NODE_TYPE.kStreet)
                {
                    m_target = m_target.RIGHT;
                    return;
                }
                else
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }
            case DOGDIRECTION.Down:
                if (m_target.DOWN == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }

                if (m_target.DOWN.NODETYPE == NODE_TYPE.kStreet)
                {
                    m_target = m_target.DOWN;
                    return;
                }
                else
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }
                return;
            case DOGDIRECTION.Left:
                if (m_target.LEFT == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;                    
                }

                if(m_target.LEFT.NODETYPE == NODE_TYPE.kStreet)
                {
                    m_target = m_target.LEFT;
                    return;
                }
                else
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }
            default:
                m_state = DOGPHASE.Idle;
                return;
        }
    }

    private void 
    OnTriggerEnter2D(Collider2D collision)
    {   
    }
}
