using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public GameObject MapGenObject;

    public GameObject NormalTile;
    public GameObject PathTile;
    public GameObject BuildableTile;
    public GameObject StartTile;
    public GameObject EndTile;

    //public LayerMask _layer;

    [SerializeField] private float yOffset;
    [SerializeField] private float xOffset;


    //0 = base |  2 = path | 3 = buildable | 4 = start | 5 = end tile
    
    int[,] TileMap = {
        {0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,0},
        {0,0,0,0,3,0,0,0,0,2,2,2,2,0,0,0},
        {0,0,3,2,2,2,3,0,3,2,0,0,2,3,0,0},
        {0,0,3,2,0,2,0,3,0,2,0,3,2,2,2,4},
        {0,0,0,2,0,2,2,2,0,2,0,0,0,3,0,0},
        {0,0,3,2,3,0,3,2,0,2,3,0,0,0,0,0},
        {5,2,2,2,3,0,0,2,3,2,3,0,0,0,0,0},
        {0,0,3,0,0,0,0,2,2,2,0,0,0,0,0,0}
    };
    private void Start()
    {
        GenerateMap();
    }
    void GenerateMap()
    {
        for (int y = 0; y < TileMap.GetLength(1); y++)
        {
            for (int x = 0; x < TileMap.GetLength(0); x++)
            {
                if (TileMap[x,y] == 0)
                {
                    
                    GameObject newTile = Instantiate(NormalTile);
                    newTile.transform.position = new Vector2(y-yOffset, x-xOffset);
                    newTile.transform.parent = MapGenObject.transform;
                }
                else if (TileMap[x,y] == 2)
                {
                    GameObject newTile = Instantiate(PathTile);
                    newTile.transform.position = new Vector2(y - yOffset, x - xOffset);
                    newTile.transform.parent = MapGenObject.transform;
                }
                else if (TileMap[x,y] == 3)
                {
                    GameObject newTile = Instantiate(BuildableTile);
                    newTile.transform.position = new Vector2(y - yOffset, x - xOffset);
                    newTile.transform.parent = MapGenObject.transform;
                    
                }
                else if (TileMap[x, y] == 4)
                {
                    GameObject newTile = Instantiate(StartTile);
                    newTile.transform.position = new Vector2(y - yOffset, x - xOffset);
                    newTile.transform.parent = MapGenObject.transform;
                }
                else if (TileMap[x, y] == 5)
                {
                    GameObject newTile = Instantiate(EndTile);
                    newTile.transform.position = new Vector2(y - yOffset, x - xOffset);
                    newTile.transform.parent = MapGenObject.transform;
                }
            }
            
        }

    }
}