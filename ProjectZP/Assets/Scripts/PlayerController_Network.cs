using UnityEngine;
using UnityEngine.Networking;

public class PlayerController_Network : NetworkBehaviour {

    public GameObject projectile;
    public float speed;
    public float moveLimit;

    public GameObject movementSphere;

    private bool isMoving;
    private float distance;
    private Vector3 targetPos;
    private Vector3 mousePos;

	// Use this for initialization
	void Start () {
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

            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = -1;
            distance = Vector3.Distance(transform.position, targetPos);
            movementSphere.transform.localScale -= new Vector3(distance * 2, distance * 2, 0);
            Debug.Log("Distance" + distance);

            isMoving = true;

            mousePos = Input.mousePosition;
            Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - currentPos.x;
            mousePos.y = mousePos.y - currentPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        
        if (Input.GetKey("escape"))
            Application.Quit();

        if (isMoving && distance > 0.01)
        {
            distance = Vector3.Distance(transform.position, targetPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        }
        else if (isMoving && distance < 0.01 && distance > 0)
            transform.position = targetPos;
        else
            isMoving = false;
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
