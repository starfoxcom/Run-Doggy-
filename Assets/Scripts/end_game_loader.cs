using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_game_loader : MonoBehaviour
{

    public GameObject [] endsprite; //sprite array
    public bool win; //win bool state

    // Start is called before the first frame update
    void Start()
    {
        
        //On win
        if(win)
        {

            //Enable sprite 0
            endsprite[0].GetComponent<SpriteRenderer>().enabled = true;
        }

        //Otherwise
        else
        {

            //Enable sprite 1
            endsprite[1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
