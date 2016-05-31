using UnityEngine;
using System.Collections;

public class SusgGameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject GameCamera;


	// Use this for initialization
	void Start () {
	    //Ensure the cursor is visible
        Cursor.visible = true;

        //spawn the player
        SpawnPlayer();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnPlayer()
    {
        Instantiate(Player);
    }
}
