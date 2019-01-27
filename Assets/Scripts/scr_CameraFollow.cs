using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraFollow : MonoBehaviour
{
    private Transform m_target;
    
    public void
    SetTarget(Transform _target)
    {
        m_target = _target;
        return;
    }

    void Start()
    {
        m_target = null;
    }
    
    void Update()
    {
        if(m_target != null)
        {
            transform.position = new Vector3(m_target.position.x, 
                                             m_target.position.y,
                                             transform.position.z);
        }
        return;
    }
}
