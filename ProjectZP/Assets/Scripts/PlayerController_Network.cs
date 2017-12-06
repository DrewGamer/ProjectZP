using UnityEngine;
using UnityEngine.Networking;

public class PlayerController_Network : NetworkBehaviour {

    public GameObject projectile;
    public GameObject energyWave;
    public bool eWave = false;
    public float speed;
    public float moveLimit;

    public GameObject movementSphere;

    public bool isMoving;
    public float distance;
    public Vector3 targetPos;
    public Vector3 mousePos;
    public Vector3 direction;

    public bool isMyTurn;

	// Use this for initialization
	void Start () {

        isMyTurn = false;

        //Makes movement sphere
        movementSphere = Instantiate(movementSphere, gameObject.transform);

        //Cannot see other ships movement range
        if (!isLocalPlayer) {

            movementSphere.GetComponent<Renderer>().enabled = false;
        }
	}

    void OnMouseUp()
    {
        if (!isLocalPlayer)
            return;

        if (WhichTurn.playerturn == 1)
        {
            Debug.Log("Click");
            MoveSelectedUnitTo();
        }
    }

    public void MoveSelectedUnitTo()
    {
        if (!isLocalPlayer)
            return;


        //transforms position of mouse on mouseUp from screen space into world space.
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = -1;
        //distance set to distance between ShipController and Mouse location on mouse up
        distance = Vector3.Distance(transform.position, targetPos);
        //changes size of movements sphere based on distance traveled
        movementSphere.transform.localScale -= new Vector3(distance * 2, distance * 2, 0);
        Debug.Log("Distance" + distance);

            isMoving = true;    



        //mouse position set to current mouse location(in pixel coordinates)
        mousePos = Input.mousePosition;
        //current position of gameobject
        Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

        //used for calculating angle of ship
        mousePos.x = mousePos.x - currentPos.x;
        mousePos.y = mousePos.y - currentPos.y;

        //changes direction ship is facing on click

             isMoving = true;

             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
         
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));


    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        
        
        //resets movements sphere
        if (Input.GetKey("space"))
        {
            movementSphere.transform.localScale = new Vector3(moveLimit, moveLimit, 0.1f);
        }
        //quits application

        if (Input.GetKey("escape"))
            Application.Quit();


        //movement of ship
        if (isMoving && distance > 0.01)
        {
            distance = Vector3.Distance(transform.position, targetPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        }
        else if (isMoving && distance < 0.01 && distance > 0)
            transform.position = targetPos;
        else
            isMoving = false;

        //laser
        if (Input.GetKeyDown("b"))
        {
            projectile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.Find("WIPship").rotation );
            projectile.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("n"))
        {
            if (!eWave)
            {
                energyWave = Instantiate(energyWave, gameObject.transform.position, gameObject.transform.rotation);
                eWave = true;
            }
            energyWave.transform.position = gameObject.transform.position;
            energyWave.gameObject.SetActive(true);
        }

    }


    void OnGUI()
    {

        if (GUILayout.Button("Move"))
        {
            movementSphere = Instantiate(movementSphere, gameObject.transform);
            movementSphere.transform.localScale = new Vector3(moveLimit, moveLimit, 0.1f);
        }

        if (GUILayout.Button("Attack"))
        {

        }

        if(GUILayout.Button("End Turn"))
        {

        }
    }




}
