using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float speed = 0.0f;
    bool isMoving = false;
    public Vector3 target;

    public Grid playerGrid;
    public GameObject P1;
    public GameObject P2;

    // Use this for initialization
    void Start () {

        P1 = Instantiate(P1, new Vector3(1, 1, -3), transform.rotation);
        playerGrid.tiles[0, 0].isOccupied = true;
        playerGrid.tiles[9, 9].isOccupied = true;
        P2 = Instantiate(P2, new Vector3(10, 10, -3), transform.rotation);


    }
    
	int CastX(GameObject go)
    {
        return (int)go.transform.position.x;
    }
    int CastY(GameObject go)
    {
        return (int)go.transform.position.y;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Up");
            if (P1.transform.position.y < playerGrid.tClamp )
            {
                target = P1.transform.position += new Vector3(0, 1, 0);
                isMoving = true;
                //P1.transform.position += new Vector3(0, 1, 0);
                //P1.transform.position = Vector3.MoveTowards(P1.transform.position, P1.transform.position += Vector3.up, 0.5f);
                //P1.transform.Translate(new Vector3(0,1,0) * Time.deltaTime, Space.Self);
                if (isMoving)
                {
                    P1.transform.position = Vector3.MoveTowards(P1.transform.position, target, 0.1f * Time.deltaTime);

                    if(P1.transform.position == target)
                    {
                        isMoving = false;
                    }
                }
                if (playerGrid.tiles[CastX(P1)-1, CastY(P1)-1].isOccupied)
                {
                    //P1.transform.position += new Vector3(0, -1, 0);
                    
                }
                else
                {
                   // playerGrid.tiles[CastX(P1)-1, CastY(P1) - 2].isOccupied = false;
                    //playerGrid.tiles[CastX(P1)-1, CastY(P1)-1].isOccupied = true;
                }
            }
            
        }
        else if (Input.GetKeyDown("down"))
        {
            if (P1.transform.position.y > playerGrid.bClamp)
            {
                P1.transform.position += new Vector3(0, -1, 0);
                if (playerGrid.tiles[CastX(P1) - 1, CastY(P1) - 1].isOccupied)
                {
                    P1.transform.position += new Vector3(0, 1, 0);
                }
                else
                {
                    playerGrid.tiles[CastX(P1)-1, CastY(P1)].isOccupied = false;
                    playerGrid.tiles[CastX(P1)-1, CastY(P1)-1].isOccupied = true;
                }
            }
        }
        else if (Input.GetKeyDown("left"))
        {
            if(P1.transform.position.x > playerGrid.bClamp)
            {
                P1.transform.position += new Vector3(-1, 0, 0);
                if (playerGrid.tiles[CastX(P1) - 1, CastY(P1) - 1].isOccupied)
                {
                    P1.transform.position += new Vector3(1, 0, 0);
                }
                else
                {
                    playerGrid.tiles[CastX(P1), CastY(P1)-1].isOccupied = false;
                    playerGrid.tiles[CastX(P1)-1, CastY(P1)-1].isOccupied = true;
                }
            }
        }
        else if (Input.GetKeyDown("right"))
        {
            if (P1.transform.position.x < playerGrid.tClamp)
            {
                P1.transform.position += new Vector3(1, 0, 0);
                if (playerGrid.tiles[CastX(P1) - 1, CastY(P1) - 1].isOccupied)
                {
                    P1.transform.position += new Vector3(-1, 0, 0);
                }
                else
                {
                    playerGrid.tiles[CastX(P1)-2, CastY(P1)-1].isOccupied = false;
                    playerGrid.tiles[CastX(P1)-1, CastY(P1)-1].isOccupied = true;
                }
            }
        }
    }
}
