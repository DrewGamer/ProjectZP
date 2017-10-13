using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Quaternion spawnRot = transform.rotation;
            GameObject laser = Instantiate(projectile, transform.position, spawnRot);
        }       
    }
}
