using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FASEDIA
{
    dia = 0, tarde, noche, mediaNoche
}

public class scr_gameMaster : CustomModule<scr_gameMaster>
{
    private FASEDIA m_fase;

    private float m_time;

    private float m_sixpm;

    private float m_ninepm;

    static float MAX_TIME = 15f;

    public void update()
    {
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
        m_ninepm = MAX_TIME - (MAX_TIME * 0.8f);
    }

    public FASEDIA FASE
    {
        get { return m_fase; }
    }

    public override void Prepare()
    {
    }

    public override void SetFree()
    {
    }
    
}
