using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gameMasterHelper : MonoBehaviour
{
    scr_gameMaster m_master;

    public Sprite[] cespedTiles;
    public Sprite[] CalleTiles;
    public Sprite[] TformTiles;
    public Sprite[] codoTiles;
    public Sprite[] Xtile;

    void ChangeSpritesColor(string tag, Sprite[] sprites)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(tag);

        if (m_master.FASE == FASEDIA.tarde)
        {
            foreach (GameObject tile in objetos)
            {
                tile.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
        }
        else if (m_master.FASE == FASEDIA.mediaNoche)//noche solo asi para debuggeo
        {
            foreach (GameObject tile in objetos)
            {
                tile.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
        }
    }

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
        ChangeSpritesColor("cesped", cespedTiles);
        ChangeSpritesColor("calle", CalleTiles);
        ChangeSpritesColor("T", TformTiles);
        ChangeSpritesColor("codo", codoTiles);
        ChangeSpritesColor("interseccion", Xtile);
    }
}
