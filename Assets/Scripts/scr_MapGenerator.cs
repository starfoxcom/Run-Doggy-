using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[RequireComponent(typeof(scr_NodeGrid))]
public class scr_MapGenerator
    : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    // Public Properties                                                    //
    //////////////////////////////////////////////////////////////////////////

    public GameObject m_tile;
    public GameObject m_prefabNode;
    public Sprite[] sprites;
    public Sprite[] houses;


    List<Vector3> dogSpawns;
    List<Vector3> houseSpawns;
    List<Vector3> enemySpawns;

    public GameObject dog;
    public GameObject house;
    public GameObject[] enemies;

    public int distanciaMinimaSpawn = 10;

    //////////////////////////////////////////////////////////////////////////
    // Private Properties                                                   //
    //////////////////////////////////////////////////////////////////////////
    private string[,] m_dataGrid;

    private Vector3 m_tileInitPosition;

    private scr_NodeGrid m_nodeGrid;

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
        if (file == null)
        {
            return;
        }

        // Load file in the CSV Reader.
        CSVFileReader fileReader = new CSVFileReader(file.text);
        CSVRow row = new CSVRow();

        m_nodeGrid.Init(fileReader.NUM_COL, fileReader.NUM_ROW);

        int rowCount = -1;
        int colCount = -1;

        while (fileReader.ReadRow(row))
        {
            rowCount++;
            colCount = -1;

            foreach (string type in row)
            {
                colCount++;

                Vector3 tPosition = new Vector3(m_tileInitPosition.x + (colCount * TILE_SIZE),
                                                m_tileInitPosition.y - (rowCount * TILE_SIZE),
                                                0.0F);

                GameObject prefab = GameObject.Instantiate(m_tile, tPosition, Quaternion.identity);

                scr_Utilities.tileType x = scr_Utilities.GiveTileType(type);
                int typeNumber = scr_Utilities.setType(x);

                // Setup NODE.
                scr_Node node = m_nodeGrid.GetNode(rowCount, colCount);
                node.SetPosition(tPosition);

                if (typeNumber == 8)//casa random
                {
                    int randomHouse = Random.Range(0, 4);
                    switch (randomHouse)
                    {
                        case 0:
                            {
                                prefab.tag = "house0";
                                break;
                            }
                        case 1:
                            {
                                prefab.tag = "house1";
                                break;
                            }
                        case 2:
                            {
                                prefab.tag = "house2";
                                break;
                            }
                        case 3:
                            {
                                prefab.tag = "house3";
                                break;
                            }
                        default:
                            break;
                    }
                    prefab.GetComponent<SpriteRenderer>().sprite = houses[randomHouse];
                    node.NODETYPE = NODE_TYPE.kBlock;
                }
                else if (typeNumber == 1) //calle horizontal
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "calle";
                }
                else if (typeNumber == 2) //calle vertical
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 0);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "calle";
                }
                else if (typeNumber == 3) //calle interseccion
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 0);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "interseccion";
                }
                else if (typeNumber == 4) //calle Tright
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 0);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "T";
                }
                else if (typeNumber == 5) //calle Tleft
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, -90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "T";
                }
                else if (typeNumber == 6) //calle Tup
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 180);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "T";
                }
                else if (typeNumber == 7) //calle Tdown
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "T";
                }
                else if (typeNumber == 9) //cesped
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "cesped";
                }
                else if (typeNumber == 10) //reloj
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 90);
                    prefab.tag = "reloj";
                }
                else if (typeNumber == 14) //calle codo
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 0);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "codo";
                }
                else if (typeNumber == 16) //calle codo
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, -90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "codo";
                }
                else if (typeNumber == 17) //calle codo
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, -180);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "codo";
                }
                else if (typeNumber == 18) //calle codo
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    prefab.transform.eulerAngles = new Vector3(0, 0, 90);
                    node.NODETYPE = NODE_TYPE.kStreet;
                    prefab.tag = "codo";
                }
                else if (typeNumber == 12) // Dog Spawn Point.
                {
                    tPosition.z = -0.1f;
                    dogSpawns.Add(tPosition);
                    node.NODETYPE = NODE_TYPE.kStreet;
                }
                else if (typeNumber == 13) // Enemy House Spawn Point.
                {
                    tPosition.z = -0.1f;
                    enemySpawns.Add(tPosition);
                    node.NODETYPE = NODE_TYPE.kStreet;
                }
                else if (typeNumber == 11) // Dog House Spawn Point.
                {
                    tPosition.z = -0.1f;
                    houseSpawns.Add(tPosition);
                    node.NODETYPE = NODE_TYPE.kStreet;
                }
                else
                {
                    prefab.GetComponent<SpriteRenderer>().sprite = sprites[typeNumber];
                    node.NODETYPE = NODE_TYPE.kBlock;
                }
            }

        }

        // Build Scene
        DebugNodeGrid();

        return;
    }

    //////////////////////////////////////////////////////////////////////////
    // Private Methods                                                      //
    //////////////////////////////////////////////////////////////////////////
    void instanciateDog()
    {
        Instantiate(dog, dogSpawns[Random.Range(0, 2)], Quaternion.identity);
    }

    void instanciateEnemies()
    {
        int pos1 = Random.Range(0, enemySpawns.Count - 1);
        enemySpawns.RemoveAt(pos1);
        int pos2 = Random.Range(0, enemySpawns.Count - 1);

        Instantiate(enemies[0], enemySpawns[pos1], Quaternion.identity);
        Instantiate(enemies[1], enemySpawns[pos2], Quaternion.identity);
    }

    void instanciateHouse()
    {
        int pos = Random.Range(0, houseSpawns.Count - 1);
        float distancia = Vector3.Distance(dog.transform.position, houseSpawns[pos]);
        Debug.Log(distancia);
        if (distancia > distanciaMinimaSpawn)
        {
            Instantiate(house, houseSpawns[pos], Quaternion.identity);
            return;
        }
        else
        {
            houseSpawns.RemoveAt(pos);
            instanciateHouse();
        }
    }


    void
    DebugNodeGrid()
    {
        for (int row = 0; row < m_nodeGrid.NUMROWS; ++row)
        {
            for (int col = 0; col < m_nodeGrid.NUMCOLS; ++col)
            {
                scr_Node node = m_nodeGrid.GetNode(row, col);
                if (node.NODETYPE == NODE_TYPE.kStreet)
                {
                    Instantiate(m_prefabNode, node.POSITION, Quaternion.identity);
                }
            }
        }
    }

    void
    Start()
    {
        // Init Tile Position.

        m_nodeGrid = GetComponent<scr_NodeGrid>();

        dogSpawns = new List<Vector3>();
        enemySpawns = new List<Vector3>();
        houseSpawns = new List<Vector3>();
        m_tileInitPosition = Vector3.zero;

        LoadScene("MapaTest");
        instanciateDog();
        instanciateEnemies();
        instanciateHouse();



        return;
    }

    void
    Update()
    { }
}
