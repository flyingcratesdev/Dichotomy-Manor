using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Trigger detection for player collision
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Find and destroy the object tagged as "Door"
            GameObject door = GameObject.FindWithTag("Door");
            if (door != null)
            {
                Destroy(door); // Destroy the door object
                Debug.Log("Door destroyed.");
            }
            else
            {
                Debug.LogError("No object found with tag 'Door'.");
            }

            // Find and destroy the object tagged as "Key"
            GameObject key = GameObject.FindWithTag("Key");
            if (key != null)
            {
                Destroy(key); // Destroy the key object
                Debug.Log("Key destroyed.");
            }
            else
            {
                Debug.LogError("No object found with tag 'Key'.");
            }
        }
    }
}
