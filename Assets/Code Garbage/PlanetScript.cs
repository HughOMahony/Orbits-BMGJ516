using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {
    float orbitSpeed = 1;
    float spotterSpawn = 1;
    GameObject cone1;
    GameObject cone2;
    GameObject cone3;


    // Use this for initialization
    void Start () {
        orbitSpeed = Random.Range(2, 20);
        if (Random.value > 0.5f)
            orbitSpeed *= -1;
        spotterSpawn = Random.Range(2, 20) + Time.realtimeSinceStartup;
        cone1 = transform.Find("visioncone1").gameObject;
        cone1.SetActive(false);
        cone2 = transform.Find("visioncone2").gameObject;
        cone2.SetActive(false);
        cone3 = transform.Find("visioncone3").gameObject;
        cone3.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.RotateAround(Vector3.zero, Vector3.forward, orbitSpeed * Time.deltaTime);
        if (!cone1.activeSelf && Time.realtimeSinceStartup > spotterSpawn)
        {
            cone1.SetActive(true);
            spotterSpawn = Random.Range(10, 30) + Time.realtimeSinceStartup;
        } else if (!cone2.activeSelf && Time.realtimeSinceStartup > spotterSpawn)
        {
            cone2.SetActive(true);
            spotterSpawn = Random.Range(15, 35) + Time.realtimeSinceStartup;
        } else if (!cone3.activeSelf && Time.realtimeSinceStartup > spotterSpawn)
            cone3.SetActive(true);

    }
}
