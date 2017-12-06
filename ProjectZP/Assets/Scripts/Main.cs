using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    //public GameObject networkManager;
    //public GameObject playerController;
    public GameObject shipController;

	// Use this for initialization
	void Start () {
        //networkManager = Instantiate(networkManager, gameObject.transform);
		//playerController = Instantiate(playerController, gameObject.transform);
        shipController = Instantiate(shipController, gameObject.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
