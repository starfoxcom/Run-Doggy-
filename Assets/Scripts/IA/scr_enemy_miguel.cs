using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MIGUEL_STATE
{
    CalculatePath,
    Moving
}

public class scr_enemy_miguel 
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////

    public GameObject m_debugObject;

    public scr_DogController m_dog = null;

    public scr_Node m_start;

    public scr_Node m_target;

    public scr_fsm m_fsm;

    public Queue<scr_Node> m_path;

    public float m_time;

    public Vector3 m_direction;

    public Rigidbody2D m_rb;

    public Animator m_animator;

    public static float m_speed = 80.0f;

    public static float SEARCH_TIME_LAPSE = 3.0f;

    //////////////////////////////////////////////////////////////////////////
    // Public Properties                                                    //
    //////////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////
    
    public void 
    Init(scr_DogController _dog, scr_Node _startNode)
    {
        m_animator = GetComponent<Animator>();

        m_rb = GetComponent<Rigidbody2D>();

        m_direction = Vector3.zero;

        // Setup Start Node.
        transform.position = _startNode.POSITION;
        m_start = _startNode;

        // Setup Dog.
        m_dog = _dog;

        m_path = new Queue<scr_Node>();

        m_fsm = new scr_fsm();
        m_fsm.Init();

        m_fsm.AddState(new Scr_miguel_calculatePath(this));
        m_fsm.AddState(new Scr_miguel_followPath(this));

        m_fsm.SetState((int)MIGUEL_STATE.CalculatePath);
        return;
    }

    public void
    DebugPath()
    {
        foreach (scr_Node node in m_path)
        {
            Instantiate(m_debugObject, node.POSITION, Quaternion.identity);
        }
    }


    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////
    
    // Update is called once per frame
    void 
    FixedUpdate()
    {       
        m_fsm.Update();

        Vector2 dir = m_direction;
        m_animator.SetFloat("angle", Vector2.SignedAngle(dir, Vector2.up));
        
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            scr_gameMaster.GetSingleton().Lose();
            return;
        }
    }
}
