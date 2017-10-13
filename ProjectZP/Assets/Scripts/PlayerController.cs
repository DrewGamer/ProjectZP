using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject currentUnit;
    public float speed;
    private bool isMoving;
    private Vector3 mousePos;
    private float distance;

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseUp()
    {
        Debug.Log("hi or whatever");
        mousePos = Input.mousePosition;
        Vector3 currentPos = Camera.main.WorldToScreenPoint(currentUnit.transform.position);

        mousePos.x = mousePos.x - currentPos.x;
        mousePos.y = mousePos.y - currentPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        currentUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        distance = Vector3.Distance(currentUnit.transform.position, mousePos);
        Debug.Log("Distance" + distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (distance > 0.1)
        {
            distance = Vector3.Distance(currentUnit.transform.position, mousePos);
            currentUnit.transform.position = Vector3.Lerp(currentUnit.transform.position, new Vector3(mousePos.x, mousePos.y, -1), speed);
        }
    }
}
