using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MapGenerator 
    : MonoBehaviour
{
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
        // Get File
        TextAsset file;
        file = Resources.Load(_fileName) as TextAsset;


    }

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }
}
