using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
    float rotateSpeed = 1;
	// Use this for initialization
	void Start () {
        rotateSpeed = Random.Range(3, 20);
        if (Random.value > 0.5f)
            rotateSpeed *= -1;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
