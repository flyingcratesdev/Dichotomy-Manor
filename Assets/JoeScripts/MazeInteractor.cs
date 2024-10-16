using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInteractor : MonoBehaviour
{
    public GameObject player;
    public GameObject mazeCamera;
    public MarbleControl maze;
    public bool isOnMaze = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnMaze && Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
            mazeCamera.SetActive(true);
            maze.enabled = true;
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MazeTrigger>())
        {

            isOnMaze = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MazeTrigger>())
        {

            isOnMaze = false;
        }
    }
}
