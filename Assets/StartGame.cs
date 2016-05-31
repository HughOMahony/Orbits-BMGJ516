using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
    public GameObject player;
    private AudioClip ac;
    public AudioSource aus;
    private Animator anim;
	// Use this for initialization
	void Start () {
     aus = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void letsBegin()
    {
        player.SetActive(true);
        aus.clip = ac;
        anim.enabled = false;

    }
}
