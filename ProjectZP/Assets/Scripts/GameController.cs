using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    /*
    [SyncVar]
    public int currentPlayerTurn;
    [SyncVar]
    public int totalPlayers;
    */

	// Use this for initialization
	void Start () {
        //currentPlayerTurn = 1;
	}
	
	// Update is called once per frame
	void Update () {

    }

    /*
    void OnPlayerConnected(NetworkPlayer player)
    {
        totalPlayers++;
    }

    public void NextPlayerTurn()
    {
        currentPlayerTurn++;
        
        if (currentPlayerTurn > totalPlayers)
            currentPlayerTurn = 1;
    }
    */
}
