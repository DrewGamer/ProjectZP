using UnityEngine;
using UnityEngine.Networking;

public class PlayerController_Network : NetworkBehaviour {

    public GameObject networkController;
    public GameObject energyWave;
    public bool eWave = false;
    public float speed;
    /*
    public float moveLimit;

    public GameObject movementSphere;

    public bool isMoving;
    public float distance;
    public Vector3 targetPos;
    public Vector3 mousePos;
    public Vector3 direction;

    public bool isMyTurn;
    */
    [SyncVar]public int turnNumber;

    //variables for keyboard movement
    public float acceleration;
    public float topSpeed;
    public float turnSpeed;

    public GameObject gunFireLocation;
    public GameObject projectileBullet;
    public int fireRateBullet;
    public float spreadBullet;
    private bool firingGun = false;

    public GameObject laserFireLocation;
    public GameObject projectileLaser;
    public int fireRateLaser;
    public float spreadLaser;
    private bool firingLaser = false;

    private Vector3 targetRot;
    private int timerBullet = 0;
    private int timerLaser = 0;

    public Canvas gunUI;
    public Canvas laserUI;

	// Use this for initialization
	void Start () {
        Network.sendRate = 69;
        //isMyTurn = false;

        turnNumber = int.Parse(GetComponent<NetworkIdentity>().netId.ToString());

        //Makes movement sphere
        //movementSphere = Instantiate(movementSphere, gameObject.transform);

        //Cannot see other ships movement range
        if (!isLocalPlayer) {
            gunUI.enabled = false;
            laserUI.enabled = false;
            //movementSphere.GetComponent<Renderer>().enabled = false;
        }

        //initialization for keyboard movement
        targetRot = transform.rotation.eulerAngles;
    }

    void OnMouseUp()
    {
        if (!isLocalPlayer)// || !isMyTurn)
            return;

        /*
        if (isMyTurn)//WhichTurn.playerturn == 1)
        {
            MoveSelectedUnitTo();
        }
        */
    }

    /*
    public void MoveSelectedUnitTo()
    {
        if (!isLocalPlayer) || !isMyTurn)
            return;

        //transforms position of mouse on mouseUp from screen space into world space.
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = -1;
        //distance set to distance between ShipController and Mouse location on mouse up
        distance = Vector3.Distance(transform.position, targetPos);
        //changes size of movements sphere based on distance traveled
        movementSphere.transform.localScale -= new Vector3(distance * 2, distance * 2, 0);

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
    */

    // Update is called once per frame
    void Update()
    {
        /*
        if (networkController.GetComponent<GameController>().currentPlayerTurn == turnNumber)
            isMyTurn = true;
        else
            isMyTurn = false;
        */

        if (!isLocalPlayer)
            return;


        /*resets movements sphere
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
            */

        if (Input.GetKeyDown("j"))
            firingGun = true;
        if (Input.GetKeyDown("l"))
            firingLaser = true;
        if (Input.GetKeyUp("j"))
            firingGun = false;
        if (Input.GetKeyUp("l"))
            firingLaser = false;
        //gun
        if (Input.GetKey("j") && timerBullet > fireRateBullet && !firingLaser && GetComponent<GunAmmo>().currentAmmo >= 1)
        {
            GetComponent<GunAmmo>().CmdLoseAmmo(1);
            CmdFireBullet();
            timerBullet = 0;
        }
        else
            timerBullet++;
        //laser
        GetComponent<LaserEnergy>().CmdRegenEnergy();
        if (Input.GetKey("l") && timerLaser > fireRateLaser && !firingGun && GetComponent<LaserEnergy>().currentEnergy >= 5)
        {
            GetComponent<LaserEnergy>().CmdLoseEnergy(5);
            CmdFireLaser();
            timerLaser = 0;
        }
        else
            timerLaser++;

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


        //testing movement via keyboard
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * acceleration);
        }


        if (GetComponent<Rigidbody>().velocity.magnitude > topSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * topSpeed;
        }

        if (Input.GetKey("a"))
        {
            //targetRot.z += 1;
            //GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Time.deltaTime * turnSpeed, ForceMode.Acceleration);
            transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
            turnSpeed++;
        }
        else if (Input.GetKey("d"))
        {
            //targetRot.z -= 1;
            //GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * Time.deltaTime * turnSpeed, ForceMode.Acceleration);
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
            turnSpeed++;
        }
        else
            turnSpeed = 30;

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), Time.fixedDeltaTime * turnSpeed);
    }

    [Command]
    void CmdFireBullet()
    {
        GameObject bullet = Instantiate(projectileBullet, gunFireLocation.transform.position, gameObject.transform.Find("WIPship").rotation);
        bullet.GetComponent<GunForceScript>().parent = gameObject;

        bullet.transform.Rotate(0, Random.Range(-spreadBullet, spreadBullet), 0);

        gunFireLocation.GetComponent<AudioSource>().Play();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }
    [Command]
    void CmdFireLaser()
    {
        GameObject laser = Instantiate(projectileLaser, laserFireLocation.transform.position, gameObject.transform.Find("WIPship").rotation);
        laser.GetComponent<LaserForceScript>().parent = gameObject;

        laser.transform.Rotate(0, Random.Range(-spreadLaser, spreadLaser), 0);

        laserFireLocation.GetComponent<AudioSource>().Play();

        laser.GetComponent<Rigidbody>().velocity = laser.transform.forward * 15;

        NetworkServer.Spawn(laser);

        Destroy(laser, 2.0f);
    }

    /*
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
            //networkController.GetComponent<GameController>().NextPlayerTurn();
        }
    }
    */




}
