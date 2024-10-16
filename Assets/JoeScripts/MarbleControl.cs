using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleControl : MonoBehaviour
{
    public float TURNSPEED = 0.01f;
    public GameObject player;
    public GameObject mazeCamera;
    public MarbleControl maze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        {
            
            ExitMaze();

        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-TURNSPEED, 0, 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(TURNSPEED, 0, 0);


        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(0, 0, -TURNSPEED);

        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(0, 0, TURNSPEED);

        }
    }
    public void ExitMaze()
    {
        player.SetActive(true);
        mazeCamera.SetActive(false);
        maze.enabled = false;

    }
}
