using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumPadScript : MonoBehaviour
{
    //Displays the numbers entered by player
    public TMP_Text returnCodeText;
    //Dispays text if the puzzle is complete or incorrect
    public TMP_Text resultText;
    //Array of chronological numbers player input
    public string[] enteredNums;
    //Array index
    public int i;
    //Maximum size of array of player input
    public int maxArraySize = 4;
    //Same as Array but condensed into one string for text purposes
    public string playerNumOrder;
    //The correct numbers that solve the puzzle
    public string correctNumOrder;
 
    // Start is called before the first frame update
    void Start()
    {
        enteredNums = new string[4];
        i = 0;

        correctNumOrder = "2024";
    }

    //Called after any number button is pressed
    public void NumButtonPress()
    {
        //Debug.Log ("Button Confirm!");
        
        //Every Button Press updates and moves up the array. Input return text is updated 
        if(i < maxArraySize)
        {
            playerNumOrder += enteredNums[i];
            returnCodeText.text = "Enter Code: " + playerNumOrder;
            //Debug.Log(playerNumOrder);
            i += 1;
        }

        //anyting over the size of the array does nothing but update the text. 
        //otherwise serves little purpose
        else
        {
            //Debug.Log(playerNumOrder);
            returnCodeText.text = "Enter Code: " + playerNumOrder;
        }
    
    }

    public void ResetPress()
    {
        //resets player input and all related text to restart the puzzle
        i = 0;
        returnCodeText.text = "Enter Code: ";
        resultText.text = "";
        enteredNums[0] = "";
        enteredNums[1] = "";
        enteredNums[2] = "";
        enteredNums[3] = "";
        playerNumOrder = "";

    }

    public void EnterPress()
    {
        //checks to see if player did the puzzle right and updates text accordingly
        if (playerNumOrder == correctNumOrder)
        {
            resultText.text = "CORRECT";
        }
        else
        {
            resultText.text = "INCORRECT";
        }
    }

    public void ExitNumPad()
    {
        //hides numpad ui when exit is pressed
        gameObject.SetActive(false);
    }

    //numbers to input, self explanitory
    //written as to not be confused with other numeric details
    //learn your spanish :)

    public void UnoPress()
    {   
        if(i < maxArraySize)
        {
            enteredNums[i] = "1";
            NumButtonPress();   
        }
    }
    public void DosPress()
    {
        if(i < maxArraySize)
        {
            enteredNums[i] = "2";
            NumButtonPress();
        }
    }
    public void TresPress()
    {
        if(i < maxArraySize)
        {
            enteredNums[i] = "3";
            NumButtonPress();
        }
    }
 public void QuatroPress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "4";
            NumButtonPress();
        }
    }
    public void CincoPress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "5";
            NumButtonPress();
        }
    }
    public void SeisPress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "6";
            NumButtonPress();
        }
    }
     public void SietePress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "7";
            NumButtonPress();
        }
    }
    public void OchoPress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "8";
            NumButtonPress();
        }
    }
    public void NuevePress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "9";
            NumButtonPress();
        }
    }
    public void CeroPress()
    {
        if (i < maxArraySize)
        {
            enteredNums[i] = "0";
            NumButtonPress();
        }
    }

}
