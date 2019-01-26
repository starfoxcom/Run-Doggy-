using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class scr_MapGenerator
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Public Properties                                                    //
    //////////////////////////////////////////////////////////////////////////

    public GameObject m_tile;
    public Sprite[] sprites;

    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////
    private string[,] m_dataGrid;

    private Vector3 m_tileInitPosition;

    //////////////////////////////////////////////////////////////////////////
    // Static Properties                                                    //
    //////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Tamaño en pixeles del Tile que vamos a utilizar.
    /// </summary>
    static int TILE_SIZE = 1;
        
    //////////////////////////////////////////////////////////////////////////
    // Public Methods                                                       //
    //////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Loads a scene from file
    /// </summary>
    /// <param name="_fileName"></param>
    public void 
    LoadScene(string _fileName)
    {
        // Get File from Resoruces Folder.
        TextAsset file;
        file = Resources.Load(_fileName) as TextAsset;

        // Check if file exists.
        if(file == null)
        {
            return;
        }

        // Load file in the CSV Reader.
        CSVFileReader fileReader = new CSVFileReader(file.text);
        CSVRow row = new CSVRow();

        int rowCount = -1;
        int colCount = -1;

        while(fileReader.ReadRow(row))
        {
            rowCount++;
            colCount = -1;

            foreach(string type in row)
            {
                colCount++;

                Vector3 tPosition = new Vector3(m_tileInitPosition.x + (colCount * TILE_SIZE), 
                                                m_tileInitPosition.y + (rowCount * TILE_SIZE), 
                                                0.0F);

                GameObject prefab = GameObject.Instantiate(m_tile, tPosition, Quaternion.identity);
                
                scr_Utilities.tileType x = scr_Utilities.GiveTileType(type);
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[scr_Utilities.setType(x)];
            }
            
        }

        // Build Scene
        BuildScene(m_dataGrid);

        return;
    }

    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////

    void
    BuildScene(string[,] _gridData)
    {

    }

    void 
    Start()
    {
        // Init Tile Position.
        m_tileInitPosition = Vector3.zero;

        LoadScene("MapaTest");

        
        return;
    }
    
    void 
    Update()
    { }
}
