using UnityEngine;

public class TrapDoorTrigger : MonoBehaviour
{
    // Reference to the falling object
    public GameObject fallingObject;

    private Rigidbody rb; // Rigidbody of the falling object

    void Start()
    {
        // Get the Rigidbody component from the falling object
        if (fallingObject != null)
        {
            rb = fallingObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // Disable gravity initially
                Debug.Log("Rigidbody found. Gravity disabled.");
            }
            else
            {
                Debug.LogError("No Rigidbody found on the falling object.");
            }
        }
        else
        {
            Debug.LogError("Falling object reference is not set in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");

            if (rb != null)
            {
                rb.useGravity = true; // Enable gravity to make the object fall
                Debug.Log("Gravity enabled for the falling object.");
            }
        }
    }
}
