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

    private void Start()
    {
        if (isBlock)
        {
            gridPosition = currentSpot.gridPosition;
            currentSpot.isOccupied = true;

        }
    }
    public void ShowFrame(bool show)
    {

        frame.SetActive(show);


    }
}
