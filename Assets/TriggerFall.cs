using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    // Reference to the falling object
    public GameObject fallingObject;

    private Rigidbody rb; // Rigidbody of the falling object

    void Start()
    {
        // Get the Rigidbody component of the falling object and disable gravity at the start
        rb = fallingObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // Disable gravity initially
            Debug.Log("Rigidbody found. Gravity disabled for object: " + fallingObject.name);
        }
        else
        {
            Debug.LogError("No Rigidbody attached to the falling object.");
        }

        // Add a Collider to the object this script is attached to, and set it as a trigger
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true; // Ensure this object’s collider is set to trigger
        }
        else
        {
            Debug.LogError("No collider found on this object. Please attach a collider.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name); // Log the triggering object name

        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");

            if (rb != null)
            {
                // Ensure gravity is enabled when the player enters the trigger zone
                rb.useGravity = true; // Enable gravity on the falling object
                Debug.Log("Gravity enabled for falling object: " + fallingObject.name);

                // Log Rigidbody state to confirm gravity is being applied
                Debug.Log($"Rigidbody state after enabling gravity: UseGravity = {rb.useGravity}, IsKinematic = {rb.isKinematic}");
            }
            else
            {
                Debug.LogError("Rigidbody is null. Cannot enable gravity.");
            }
        }
    }
}
