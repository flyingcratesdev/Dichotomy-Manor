using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public FPSController FPSController;
    public GameObject slidingPuzzle;
    bool isTriggered = false;
    bool isSolvedSliding = false;
    bool isTriggeredPhaseTwo = false;
    public GameObject DirectionsText;


    // Update is called once per frame
    void Update()
    {

        if (!isSolvedSliding)
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
        if(isTriggeredPhaseTwo)
        {

            DirectionsText.SetActive(true);

        }else
        {

            DirectionsText.SetActive(false);
        }

    }
    public void CompleteSlidingPuzzle()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        slidingPuzzle.SetActive(false);
        FPSController.enabled = true;
        isSolvedSliding = true;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SlidingPuzzleTrigger>())
        {


            isTriggered = true;

        }
        if (other.GetComponent<SlidingPuzzlePhaseTwo>())
        {



            isTriggeredPhaseTwo = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SlidingPuzzleTrigger>())
        {



            isTriggered = false;



        }
        if (other.GetComponent<SlidingPuzzlePhaseTwo>())
        {



            isTriggeredPhaseTwo = false;

        }
    }
}
