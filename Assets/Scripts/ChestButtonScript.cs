using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestButtonScript : MonoBehaviour
{
    public Color[] buttonColors;
    private int currentColorIndex = 0; 
    private Renderer buttonRenderer; 

    void Start()
    {
     
        buttonRenderer = GetComponent<Renderer>();

  
        if (buttonColors.Length > 0)
        {
            buttonRenderer.material.color = buttonColors[currentColorIndex];
        }
    }

    void OnMouseDown()
    {
    
        currentColorIndex = (currentColorIndex + 1) % buttonColors.Length;


        buttonRenderer.material.color = buttonColors[currentColorIndex];


        Debug.Log($"Button pressed. Current color: {buttonColors[currentColorIndex]}");
    }

    public Color GetCurrentColor()
    {
        return buttonRenderer.material.color;
    }
}

