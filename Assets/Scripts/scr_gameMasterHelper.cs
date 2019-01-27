using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gameMasterHelper : MonoBehaviour
{
    scr_gameMaster m_master;
    // Start is called before the first frame update
    void Start()
    {
        m_master = scr_gameMaster.GetSingleton();
        m_master.init();
    }

    // Update is called once per frame
    void Update()
    {
        m_master.update();
    }
}
