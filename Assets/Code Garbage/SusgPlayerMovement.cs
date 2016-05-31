
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SusgPlayerMovement : MonoBehaviour
{

    private Rigidbody _PlayerRB;
    private GameObject _ClosestPlanet;
    private float _ClosestDistanceFromPlayer;
    private Vector3 _CursorPosition;
    private Vector3 _TargetPosition;
    private float _DistanceFromCursor;

    public int score = 0;


    public GameObject killscreen;


    private bool _bIsMiningResources;

    public float Speed = 1f;
    public float OrbitDistanceThreshold = 5f;
    public float CursorDistanceThreshold = 16f;
    public GameObject ScoreBoard;
    private Text ScoreText;

    // Use this for initialization
    void Start()
    {
        _PlayerRB = GetComponent<Rigidbody>();

        ScoreText = ScoreBoard.GetComponent<Text>();
        ScoreText.text = score + " Points so far...";
    }

    void FixedUpdate()
    {
        //goes under the mousePosition defenition


        ScoreText.text = score + " Points so far...";

        //create a ray cast and set it to the mouses cursor position in game
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, 50f))
        // {

        //hacky shit
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _CursorPosition = mousePosition;

        //goes under the mousePosition defenition

        float mouseX = mousePosition.x - transform.position.x;
        float mouseY = mousePosition.y - transform.position.y;

        float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        //save the hit point as the cursor position
        // _CursorPosition = hit.point;

        //get the distance from the cursor
        _DistanceFromCursor = Vector3.Magnitude(_CursorPosition - transform.position);


        // }

        //create an array of planets
        GameObject[] Planets = GameObject.FindGameObjectsWithTag("Planet");

        //check distance to all planets
        foreach (GameObject Planet in Planets)
        {
            //get the distance from it
            float DistanceFromPlayer = Vector3.Magnitude(Planet.transform.position - transform.position);
            //Debug.Log(DistanceFromPlayer);

            if (_ClosestPlanet == null)
            {
                //store the closest one in a temp GO var
                _ClosestPlanet = Planet;
            }
            else
            {
                _ClosestDistanceFromPlayer = Vector3.Magnitude(_ClosestPlanet.transform.position - transform.position);

                if (DistanceFromPlayer < _ClosestDistanceFromPlayer)
                {
                    DistanceFromPlayer = _ClosestDistanceFromPlayer;
                    _ClosestPlanet = Planet;
                }

            }
        }


        //if distance is less than threshold


        if (_ClosestDistanceFromPlayer < OrbitDistanceThreshold && _DistanceFromCursor < CursorDistanceThreshold)
        {
            Debug.Log("harvesting");
            score++;
            //get the position of the planet and set it to the target
            if (_ClosestPlanet != null)
                _TargetPosition = _ClosestPlanet.transform.position;
        }
        else //else, move the player towards the mouse cursor
        {
            //set the target position as the point
            _TargetPosition = _CursorPosition;
        }

        //lerp to the new position

        Vector2 NewPosition = Vector2.Lerp(transform.position, _TargetPosition, Time.deltaTime * Speed);
       // NewPosition.z = 0;

        //set the new position
        transform.position = NewPosition;



    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bleh");
        killscreen.SetActive(true);
    }
}

/*
mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, Time.deltaTime * Speed);














        }
}
*/
