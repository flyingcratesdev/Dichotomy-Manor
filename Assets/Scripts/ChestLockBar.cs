using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLockBar : MonoBehaviour
{
    public ChestButtonScript[] buttons; // Array of all buttons on the chest
    private Color[] correctColors = { Color.red, Color.green, Color.blue }; // Replace with your correct pattern

    public void CheckButtonColors()
    {
        // Ensure the buttons array and correctColors array lengths match
        if (buttons.Length != correctColors.Length)
        {
            Debug.LogError("Mismatch between number of buttons and correct colors!");
            return;
        }

        // Check each button's color against the correct color
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetCurrentColor() != correctColors[i])
            {
                Debug.Log("Lock is still engaged. Buttons are not set correctly.");
                return; // Exit if even one button is incorrect
            }
        }

        // All colors match
        UnlockChest();
    }

    private void UnlockChest()
    {
        Debug.Log("Chest unlocked!");
        // Add unlocking logic here, such as animations or sound effects
        GetComponent<Animator>()?.SetTrigger("Unlock"); // Example animation trigger
    }
}
