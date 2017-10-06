using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rotZ = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, rotZ);
        transform.Translate(0, y, 0);

        if (Input.GetKey("escape"))
            Application.Quit();


    }
}
