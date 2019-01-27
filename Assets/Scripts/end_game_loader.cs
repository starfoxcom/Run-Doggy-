using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game_loader : MonoBehaviour
{

    public GameObject [] endsprite; //sprite array    

    // Start is called before the first frame update
    void Start()
    {
        
        //On win
        if(scr_gameMaster.GetSingleton().STATUS == GAMESTATUS.Win)
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

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
}
