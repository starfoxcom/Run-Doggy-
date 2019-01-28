using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas; //The canvas of the menu

    void Update()
    {
     
        //On any key pressed
        if(Input.anyKeyDown)
        {
            
            //Disable canvas
            canvas.SetActive(false);

            //Unpause Game
            scr_gameMaster.GetSingleton().Pause(false);
        }
        
    }

    
}
