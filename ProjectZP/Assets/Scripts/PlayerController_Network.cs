using UnityEngine;
using UnityEngine.Networking;

public class PlayerController_Network : NetworkBehaviour {

    public GameObject projectile;
    public GameObject energyWave;
    public bool eWave = false;
    public float speed;
    public float moveLimit;

    public GameObject movementSphere;

    private bool isMoving;
    private float distance;
    private Vector3 targetPos;
    private Vector3 mousePos;
    private Vector3 direction;




	// Use this for initialization
	void Start () {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        //Makes movement sphere
        movementSphere = Instantiate(movementSphere, gameObject.transform);

        //Cannot see other ships movement range
        if (!isLocalPlayer)
=======
        if (!isLocalPlayer) {
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
        if (!isLocalPlayer) {
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
        if (!isLocalPlayer) {
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
        if (!isLocalPlayer) {
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        //transforms position of mouse from screen space into world space.
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = -1;
        //distance set to distance of this object to distance of target position
        distance = Vector3.Distance(transform.position, targetPos);
        //changes size of movements sphere based on distance traveled
        movementSphere.transform.localScale -= new Vector3(distance * 2, distance * 2, 0);
        Debug.Log("Distance" + distance);
=======
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = -1;
            distance = Vector3.Distance(transform.position, targetPos);
            movementSphere.transform.localScale -= new Vector3(distance * 2, distance * 2, 0);
            Debug.Log("Distance" + distance);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

            isMoving = true;
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======

            isMoving = true;
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b

            mousePos = Input.mousePosition;
            Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

<<<<<<< HEAD
<<<<<<< HEAD
        //mouse position set to current mouse location(in pixel coordinates)
        mousePos = Input.mousePosition;
        //current position of gameobject
        Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

        //used for calculating angle of ship
        mousePos.x = mousePos.x - currentPos.x;
        mousePos.y = mousePos.y - currentPos.y;
=======
            mousePos.x = mousePos.x - currentPos.x;
            mousePos.y = mousePos.y - currentPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

<<<<<<< HEAD
        //changes direction ship is facing on click
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======

            isMoving = true;

            mousePos = Input.mousePosition;
            Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - currentPos.x;
            mousePos.y = mousePos.y - currentPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======

            isMoving = true;

            mousePos = Input.mousePosition;
            Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - currentPos.x;
            mousePos.y = mousePos.y - currentPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
            mousePos.x = mousePos.x - currentPos.x;
            mousePos.y = mousePos.y - currentPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        //resets movements sphere
        if (Input.GetKey("space"))
        {
            movementSphere.transform.localScale = new Vector3(moveLimit, moveLimit, 0.1f);
        }
        //quits application
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
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

        if (Input.GetKeyDown("b"))
        {
            projectile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation );
            projectile.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("n"))
        {
            if (!eWave)
            {
                energyWave = Instantiate(energyWave, gameObject.transform.position, gameObject.transform.rotation);
                eWave = true;
            }
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


<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
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


<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
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


>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
=======
>>>>>>> 221e4c0493f4ca6083e69305f39e3635ad2caa4b
}
