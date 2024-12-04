using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestLockBar : MonoBehaviour
{
    public ChestButton[] buttons; // Array of all buttons
    public Color[] correctColors; // The correct color sequence to unlock

    public void CheckButtonColors()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // Check if each button's color matches the correct color
            if (buttons[i].GetCurrentColor() != correctColors[i])
            {
                Debug.Log("Lock is still engaged. Buttons are not set correctly.");
                return; // Exit if even one button is incorrect
            }
        }

        // If all buttons match, unlock the chest
        UnlockChest();
    }

    private void UnlockChest()
    {
        Debug.Log("Chest unlocked!");
        // Add chest unlocking logic here (e.g., animations, sounds, etc.)
    }
}

}
