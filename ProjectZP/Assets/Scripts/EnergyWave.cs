using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWave : MonoBehaviour {

    private float lifeTime;
    public float speed;

    // Use this for initialization
    void Start () {

        
}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);

        Color color = gameObject.GetComponent<Renderer> ().material.color;
        color.a -= 0.1f;
        gameObject.GetComponent<Renderer>().material.color = color;

        if (lifeTime > 40)
        {
            //Destroy(gameObject);
            
            
            gameObject.SetActive(false);
            color.a = 1.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
            gameObject.transform.localScale = new Vector3(1, 1, 0.5f);
            lifeTime = 0;
        }
        else lifeTime++;

    }
}
