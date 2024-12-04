using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject door;
    public Transform key;

    // Trigger detection for player collision
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Find and destroy the object tagged as "Door"
            if (door != null)
            {
                Destroy(door); // Destroy the door object
                Debug.Log("Door destroyed.");
            }


            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        key.Rotate(0, 0.5f, 0);
    }
}
