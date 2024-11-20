using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeInteractor : MonoBehaviour
{
    public FPSController playerScript;
    public GameObject mazeCamera;
    public GameObject marblePlayer;
    [SerializeField]
    private bool isInteracted = false;
    public bool isOnMaze = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnMaze && Input.GetKeyDown(KeyCode.E) && !isInteracted)
        {
            playerScript.enabled = false;
            mazeCamera.SetActive(true);
            marblePlayer.SetActive(true);
            isInteracted = true;

        }


        if (isInteracted && isOnMaze && Input.GetKeyDown(KeyCode.Escape))
        {
            playerScript.enabled = true;

            mazeCamera.SetActive(false);
            marblePlayer.SetActive(false);
            isInteracted = false;



        }
    }
    public void ExitMaze()
    {

        playerScript.enabled = true;

        mazeCamera.SetActive(false);
        marblePlayer.SetActive(false);
        isInteracted = false;


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
