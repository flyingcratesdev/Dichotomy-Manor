using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public FPSController FPSController;
    public GameObject slidingPuzzle;
    public GameObject reactionPuzzle;
    public GameObject spacePuzzle; //Space stuff
    bool isTriggered = false;
    bool isSpaceTriggered = false; //Space stuff
    bool isSolvedSliding = false;
    bool isTriggeredPhaseTwo = false;
    bool isOnButton = false;
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
        if (isTriggeredPhaseTwo)
        {

            DirectionsText.SetActive(true);

        }
        else
        {

            DirectionsText.SetActive(false);
        }
        if (isOnButton)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                reactionPuzzle.SetActive(true);
                FPSController.enabled = false;

            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                reactionPuzzle.SetActive(false);
                FPSController.enabled = true;


            }

        }

        if (isSpaceTriggered && Input.GetKeyDown(KeyCode.E)) //Space stuff
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            spacePuzzle.SetActive(true);
            FPSController.enabled = false;
        }
        if (isSpaceTriggered && Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            spacePuzzle.SetActive(false);
            FPSController.enabled = true;
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

    public void CompleteSpacePuzzle() //Space stuff
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spacePuzzle.SetActive(false);
        FPSController.enabled = true;
        isSolvedSliding = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SlidingPuzzleTrigger>())
        {


            isTriggered = true;

        }
        if (other.GetComponent<SlidingPuzzlePhaseTwo>())
        {



            isTriggeredPhaseTwo = true;

        }
        if (other.GetComponent<HatchButton>())
        {


            isOnButton = true;


        }

        if (other.GetComponent<SpacePuzzleTrigger>()) //Space stuff
        {
            isSpaceTriggered = true;
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
        if (other.GetComponent<HatchButton>())
        {


            isOnButton = false;

        }

        if (other.GetComponent<SpacePuzzleTrigger>()) //Space stuff
        {
            isSpaceTriggered = false;
        }
    }
}
