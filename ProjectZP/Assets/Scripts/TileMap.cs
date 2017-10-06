using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour{

    public GameObject selectedUnit;

    public TileType[] tileTypes;


    int[,] tiles;

    int mapSizeX = 20;
    int mapSizeY = 18;

    void Start()
    {
        GenerateMapData();
        GenerateMapVisual();
    }
    void GenerateMapData()
    { 
        //Allocate our map tiles
        tiles = new int[mapSizeX, mapSizeY];

        tiles[0, 0] = 0;

        //Initialize out map tiles to be grass
        for(int x=0; x< mapSizeX;x++)
        {
            for(int y=0; y<mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }



    }

    void GenerateMapVisual()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
    
                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);

                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;

            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, -1);
    }

    public void MoveSelectedUnitTo(int x, int y)
    {
        //selectedUnit.GetComponent<Unit>().tileX = x;
        //selectedUnit.GetComponent<Unit>().tileY = y;
        selectedUnit.transform.position = TileCoordToWorldCoord(x,y);
    }

	}

