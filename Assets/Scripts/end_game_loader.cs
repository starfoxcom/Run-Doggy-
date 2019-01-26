using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_game_loader : MonoBehaviour
{
    public GameObject [] endsprite;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        if(win)
        {
            endsprite[0].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            endsprite[1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
