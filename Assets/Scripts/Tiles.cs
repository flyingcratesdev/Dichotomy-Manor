using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color correctColor = Color.green; 
    public Color wrongColor = Color.red;     
    public Transform playerStartPosition;
    private bool isPlayerOnTile = false;     
    private Renderer tileRenderer;         

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerOnTile)
        {
            if (CompareTag("right"))
            {
               
                tileRenderer.material.color = correctColor;
                isPlayerOnTile = true;
            }
            else if (CompareTag("wrong"))
            {
               
                tileRenderer.material.color = wrongColor;
                other.transform.position = playerStartPosition.position; 
            }
        }
    }
}
