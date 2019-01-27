using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_nodeDebugObject : MonoBehaviour
{
    public float time;

    public static float SPAWN_TIME = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >= SPAWN_TIME)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
