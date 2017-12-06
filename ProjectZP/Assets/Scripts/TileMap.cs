using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TileMap : NetworkBehaviour{

    public PlayerController_Network selectedUnit;

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
    
    public void MoveSelectedUnitTo(int x, int y)
    {
        selectedUnit.targetPos = new Vector3(x, y, -1);

        selectedUnit.mousePos = Input.mousePosition;
        Vector3 currentPos = Camera.main.WorldToScreenPoint(selectedUnit.transform.position);

        selectedUnit.mousePos.x = selectedUnit.mousePos.x - currentPos.x;
        selectedUnit.mousePos.y = selectedUnit.mousePos.y - currentPos.y;

        float angle = Mathf.Atan2(selectedUnit.mousePos.y, selectedUnit.mousePos.x) * Mathf.Rad2Deg;

        selectedUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        selectedUnit.distance = Vector3.Distance(selectedUnit.transform.position, selectedUnit.targetPos);
        Debug.Log("Distance" + selectedUnit.distance);

        selectedUnit.isMoving = true;
    }
    
    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (isMoving && distance > 0.1)
        {
            distance = Vector3.Distance(selectedUnit.transform.position, targetPos);
            selectedUnit.transform.position = Vector3.Lerp(selectedUnit.transform.position, targetPos, speed);
        }
        else if (isMoving)
            selectedUnit.transform.position = targetPos;
        else
            isMoving = false;
    }
    */
}

