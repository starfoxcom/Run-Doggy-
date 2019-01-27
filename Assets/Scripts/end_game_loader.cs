using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game_loader : MonoBehaviour
{

    public GameObject [] endsprite; //sprite array   
    public AudioClip m_victorySound;
    public AudioClip m_loseSound;
    private AudioSource m_bocina;

    // Start is called before the first frame update
    void Start()
    {
        m_bocina = GetComponent<AudioSource>();
        //On win
        if (scr_gameMaster.GetSingleton().STATUS == GAMESTATUS.Win)
        {

            //Enable sprite 0
            endsprite[0].GetComponent<SpriteRenderer>().enabled = true;
            m_bocina.clip = m_victorySound;
            if (!m_bocina.isPlaying)
            {
                m_bocina.Play();
            }
        }

        //Otherwise
        else
        {

            //Enable sprite 1
            //endsprite[1].GetComponent<SpriteRenderer>().enabled = true;
            endsprite[1].SetActive(true);
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
