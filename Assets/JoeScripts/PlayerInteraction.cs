using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public FPSController FPSController;
    public GameObject slidingPuzzle;
    bool isTriggered = false;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            slidingPuzzle.SetActive(true);
            FPSController.enabled = false;

        }
        if (isTriggered && Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            slidingPuzzle.SetActive(false);
            FPSController.enabled = true;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SlidingPuzzleTrigger>())
        {



            isTriggered = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SlidingPuzzleTrigger>())
        {



            isTriggered = false;


        }
    }
}
