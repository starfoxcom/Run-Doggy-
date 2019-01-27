using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum FASEDIA
{
    dia = 0, tarde, noche, mediaNoche
}

public enum GAMESTATUS
{
    None = 0,
    Win,
    Lose
}

public class scr_gameMaster : CustomModule<scr_gameMaster>
{
    private FASEDIA m_fase;

    private float m_time;

    private float m_sixpm;

    private float m_ninepm;

    private bool m_paused;

    private GAMESTATUS m_gameStatus = GAMESTATUS.None;

    static float MAX_TIME = 180.0f;

    public void update()
    {
        if(m_paused)
        { return; }

        m_time += Time.deltaTime;

        switch (m_fase)
        {
            case FASEDIA.dia:

                // Poner sonido de ambientacion de ciudad.

                if (m_time > m_sixpm)
                {
                    m_fase = FASEDIA.tarde;
                }

                break;
            case FASEDIA.tarde:
                if (m_time > m_ninepm)
                {
                    m_fase = FASEDIA.noche;
                }

                break;
            case FASEDIA.noche:

                // sonidos de grillos.

                if (m_time > MAX_TIME)
                {
                    m_fase = FASEDIA.mediaNoche;
                    Lose();
                }


                break;
            case FASEDIA.mediaNoche:


                break;
            default:
                break;
        }
    }

    public void init()
    {

        // Es Dia
        m_fase = FASEDIA.dia;

        // Tiempo es 0
        m_time = 0;

        // Tiempo de las 6pm
        m_sixpm = MAX_TIME * 0.5f;

        // Tiempo de las 9pm
        m_ninepm = MAX_TIME - (MAX_TIME * 0.2f);

        // Game Status init
        m_gameStatus = GAMESTATUS.None;

        // Game Paused.
        m_paused = true;
    }

    public FASEDIA FASE
    {
        get { return m_fase; }
    }

    public GAMESTATUS STATUS
    {
        get { return m_gameStatus; }
    }

    public void 
    Win()
    {
        if (m_gameStatus != GAMESTATUS.None)
        { return; }

        m_gameStatus = GAMESTATUS.Win;

        SceneManager.LoadScene(1);

        return;
    }
    
    public void
    Pause(bool _setPause)
    {
        m_paused = _setPause;
        return;
    }

    public bool
    ISPAUSE
    {
        get { return m_paused; }
    }

    public void
    Lose()
    {
        if (m_gameStatus != GAMESTATUS.None)
        { return; }

        m_gameStatus = GAMESTATUS.Lose;

        SceneManager.LoadScene(1);

        return;
    }

    public override void Prepare()
    {
    }

    public override void SetFree()
    {
    }
    
}
