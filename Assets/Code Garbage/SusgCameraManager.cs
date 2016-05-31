using UnityEngine;
using System.Collections;

public class SusgCameraManager : MonoBehaviour {

    public float distance = 50f;
    public GameObject player;
    public float speed = 10;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called 50 frames per second
    void FixedUpdate()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = playerPos;//Vector3.Lerp(transform.position, playerPos, Time.deltaTime * speed);

    }

}
