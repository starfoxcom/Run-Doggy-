using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(scr_CsvReader))]
public class scr_MapGenerator 
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////
    private string[,] m_dataGrid;

    //////////////////////////////////////////////////////////////////////////
    // Static Properties                                                    //
    //////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Tamaño en pixeles del Tile que vamos a utilizar.
    /// </summary>
    static int TILE_SIZE = 64;
        
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
        m_dataGrid = scr_CsvReader.SplitCsvGrid(file.text);

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
        return;
    }
    
    void 
    Update()
    { }
}
