using UnityEngine;

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
[RequireComponent(typeof(Animator))]
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

    private Animator m_anim;

    static float MIN_RADIUS_NODE_DETECTION = 0.05f;

    static float SPEED = 100.0f;
    
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

    public scr_Node
    TARGET
    {
        get
        {
            return m_target;
        }
    }

    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();

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
        
        if(m_directionIndex != DOGDIRECTION.None)
        {
            m_directionIndex = DOGDIRECTION.None;
            m_anim.SetInteger("DirectionIndex", (int)DOGDIRECTION.None);
        }

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
            m_anim.SetInteger("DirectionIndex", (int)DOGDIRECTION.Up);
            m_state = DOGPHASE.Moving;
            return;
        }

        // DOWN
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_directionIndex = DOGDIRECTION.Down;
            m_anim.SetInteger("DirectionIndex", (int)DOGDIRECTION.Down);
            m_state = DOGPHASE.Moving;
            return;
        }

        // RIGHT
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_directionIndex = DOGDIRECTION.Right;
            m_anim.SetInteger("DirectionIndex", (int)DOGDIRECTION.Right);
            m_state = DOGPHASE.Moving;
            return;
        }

        // LEFT
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_directionIndex = DOGDIRECTION.Left;
            m_anim.SetInteger("DirectionIndex", (int)DOGDIRECTION.Left);
            m_state = DOGPHASE.Moving;
            return;
        }
    }

    static public float m_radio = 5;
    private void
    NodeCollision()
    {
        //revisar si el nodo esta explorado
        if (m_target.m_explored == false)
        {
            Collider[] objects = Physics.OverlapSphere(m_target.POSITION, m_radio);
            foreach (Collider collider in objects)
            {
                float distance = Vector3.Distance(collider.transform.position, transform.position);
                Color tmp = collider.GetComponent<SpriteRenderer>().color;
                if (distance < m_radio * 0.4f)
                {
                    tmp.a = 1;
                }
                else if(distance < m_radio * 0.6f)
                {
                    tmp.a += 0.6f;
                }
                else if (distance < m_radio * 0.9f)
                {
                    tmp.a += 0.3f;
                }
                collider.GetComponent<SpriteRenderer>().color = tmp;
            }
            m_target.m_explored = true;
        }

        if(m_target.NODETYPE == NODE_TYPE.kHouse)
        {
            scr_gameMaster.GetSingleton().Win();
        }

        switch(m_directionIndex)
        {
            case DOGDIRECTION.Up:
                if (m_target.UP == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }

                if (m_target.UP.NODETYPE == NODE_TYPE.kStreet
                    || m_target.UP.NODETYPE == NODE_TYPE.kHouse)
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

                if (m_target.RIGHT.NODETYPE == NODE_TYPE.kStreet
                    || m_target.RIGHT.NODETYPE == NODE_TYPE.kHouse)
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

                if (m_target.DOWN.NODETYPE == NODE_TYPE.kStreet
                    || m_target.DOWN.NODETYPE == NODE_TYPE.kHouse)
                {
                    m_target = m_target.DOWN;
                    return;
                }
                else
                {
                    m_state = DOGPHASE.Idle;
                    return;
                }
            case DOGDIRECTION.Left:
                if (m_target.LEFT == null)
                {
                    m_state = DOGPHASE.Idle;
                    return;                    
                }

                if(m_target.LEFT.NODETYPE == NODE_TYPE.kStreet
                    || m_target.LEFT.NODETYPE == NODE_TYPE.kHouse)
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
