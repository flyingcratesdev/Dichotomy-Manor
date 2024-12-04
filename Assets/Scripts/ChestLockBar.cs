using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLockBar : MonoBehaviour
{
    public ChestButtonScript[] buttons;
    private Color[] correctColors = { Color.red, Color.green, Color.blue };

    public void CheckButtonColors()
    {

        if (buttons.Length != correctColors.Length)
        {
            Debug.LogError("Mismatch between number of buttons and correct colors!");
            return;
        }


        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetCurrentColor() != correctColors[i])
            {
                Debug.Log("Lock is still engaged. Buttons are not set correctly.");
                return; // Exit if even one button is incorrect
            }
        }


        UnlockChest();
    }

    private void UnlockChest()
    {
        Debug.Log("Chest unlocked!");

        GetComponent<Animator>()?.SetTrigger("Unlock");
    }
}
