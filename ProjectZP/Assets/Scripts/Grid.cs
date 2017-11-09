using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Tile space;
    public int numberOfTiles = 100 ;
    public int tilePerRow = 10;
    public float distanceBetweenTiles = 1.0f;
    public int bClamp = 1;
    public int tClamp = 11;

    public Tile[,] tiles = new Tile[10,10];

	// Use this for initialization
	void Start () {
        CreateTiles();
	}

    void CreateTiles()
    {
        float xOffset = 1.0f;
        float yOffset = 1.0f;


        for(int i = 0; i < numberOfTiles; i++)
        {
            xOffset += distanceBetweenTiles;

            
            if (i % tilePerRow == 0)
            {
                if (i > 0)
                {
                    yOffset += distanceBetweenTiles;
                }
                xOffset = 1;
            }

          tiles[(int)xOffset-1,(int)yOffset-1] = Instantiate(space, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z ), transform.rotation);
  
        }
    }
	
	// Update is called once per frame
	
}
