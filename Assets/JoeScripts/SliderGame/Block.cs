using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isBlock;
    public int gridPosition;
    public bool isOccupied = false;
    public Block currentSpot;
    public GameObject frame;
    public int colorID = 0;
    //0 - white 1 - blue 2 - red 3 - purple



    private void Start()
    {
        if (isBlock)
        {
            gridPosition = currentSpot.gridPosition;
            currentSpot.SetOccupation(colorID, true);

        }
    }
    public void ShowFrame(bool show)
    {

        frame.SetActive(show);


    }

    public void SetOccupation(int numColor, bool occupy)
    {
        colorID = numColor;
        isOccupied = occupy;



    }
}
