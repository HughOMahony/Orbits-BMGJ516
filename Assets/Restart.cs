using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SceneManager.LoadScene("main");

    }

    public void DoOver()
    {
        GameObject[] Planets = GameObject.FindGameObjectsWithTag("Planet");

        //check distance to all planets
        foreach (GameObject Planet in Planets)
        {
            Destroy(Planet);
        }
            SceneManager.LoadScene("main");
    }
}
