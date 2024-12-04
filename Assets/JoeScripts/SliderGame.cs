using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderGame : MonoBehaviour
{
    public GameObject firstSelected;
    public GameObject secondSelected;

    public Vector2 targetPosition; // Set this to the new target position in the Inspector or script
    public float moveSpeed = 5f;   // Speed of movement

    private Vector2 startPosition; // The object's starting position
    [SerializeField]
    private bool isMoving = false; // Control whether the object should move

    [SerializeField]
    private Block[] blocks;

    private bool hasWon = false;
    public GameObject unsolved;
    public GameObject solved;
    public PlayerInteraction interactionScript;

   

    void Update()
    {
        if (isMoving)
        {
            // Move towards the target position
            firstSelected.transform.position = Vector2.Lerp(firstSelected.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving when close enough to the target
            if (Vector2.Distance(firstSelected.transform.position, targetPosition) <= 0.3f)
            {
                
                firstSelected.transform.position = targetPosition;
                secondSelected = null;
                firstSelected = null;
               
                isMoving = false; // Stop movement
            }
        }
        if (!isMoving && blocks[0].colorID == 1 && blocks[3].colorID == 1 && blocks[1].colorID == 2 && blocks[4].colorID == 2 && blocks[2].colorID == 3 && blocks[5].colorID == 3 && blocks[8].colorID == 3 && !hasWon)
        {

            unsolved.SetActive(false);
            solved.SetActive(true);
            interactionScript.CompleteSlidingPuzzle();
           
            hasWon = true;

        }


    }
    public void MoveToPosition(Vector2 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        isMoving = true;
    }

    public void OnClicked(GameObject block)
    {
        if (!isMoving)
        {
            if (firstSelected == null && block.GetComponent<Block>().isBlock)
            {

                firstSelected = block;
                firstSelected.GetComponent<Block>().ShowFrame(true);
            }
            else if (firstSelected != null && secondSelected == null && !block.GetComponent<Block>().isBlock && !block.GetComponent<Block>().isOccupied)
            {



                secondSelected = block;
                if (secondSelected.GetComponent<Block>().gridPosition == firstSelected.GetComponent<Block>().gridPosition + 1 || secondSelected.GetComponent<Block>().gridPosition == firstSelected.GetComponent<Block>().gridPosition - 1 || secondSelected.GetComponent<Block>().gridPosition == firstSelected.GetComponent<Block>().gridPosition + 3 || secondSelected.GetComponent<Block>().gridPosition == firstSelected.GetComponent<Block>().gridPosition - 3)
                {
                    MoveToPosition(secondSelected.transform.position);
                    // firstSelected.transform.position = secondSelected.transform.position;
                    firstSelected.GetComponent<Block>().currentSpot.SetOccupation(0, false);
                    firstSelected.GetComponent<Block>().currentSpot = secondSelected.GetComponent<Block>();
                    block.GetComponent<Block>().SetOccupation(firstSelected.GetComponent<Block>().colorID, true);
                    firstSelected.GetComponent<Block>().ShowFrame(false);
                    firstSelected.GetComponent<Block>().gridPosition = secondSelected.GetComponent<Block>().gridPosition;
                  
                }
                else
                    secondSelected = null;

            }
        }

    }

    public void ClearSelection()
    {
        if (!isMoving)
        {
            if (firstSelected != null)
            {
                firstSelected.GetComponent<Block>().ShowFrame(false);

                firstSelected = null;

            }
            if (secondSelected != null)
                secondSelected = null;
        }
    }
}
