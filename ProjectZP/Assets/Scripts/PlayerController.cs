using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject projectile;
    public float speed;
    public bool isMoving;
    public GameObject movementSphere;

    public float moveLimit;

    public float distance;
    public Vector3 targetPos;
    public Vector3 mousePos;

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseUp()
    {
        Debug.Log("Click");

        MoveSelectedUnitTo();
    }

    public void MoveSelectedUnitTo()
    {
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
        
        if (Input.GetKey("space"))
        {
            movementSphere.transform.localScale = new Vector3(moveLimit, moveLimit, 0.1f);
        }

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
}
