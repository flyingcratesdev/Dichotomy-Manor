using UnityEngine;

public class PlayerSliding : MonoBehaviour
{
    public Rigidbody rb; // Reference to Rigidbody
    public float slideSpeed = 5f; // Speed of sliding
    private Vector3 slideDirection; // Direction of sliding
    private bool isSliding = false; // Whether the player is currently sliding

    void Start()
    {
        // Ensure the Rigidbody component is assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        // Make sure Rigidbody settings are appropriate for movement
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    void Update()
    {
        // Check for player input to start sliding
        if (Input.GetKeyDown(KeyCode.W)) // Slide forward
        {
            slideDirection = transform.forward;
            isSliding = true;
        }
        else if (Input.GetKeyDown(KeyCode.S)) // Slide backward
        {
            slideDirection = -transform.forward;
            isSliding = true;
        }
        else if (Input.GetKeyDown(KeyCode.A)) // Slide left
        {
            slideDirection = -transform.right;
            isSliding = true;
        }
        else if (Input.GetKeyDown(KeyCode.D)) // Slide right
        {
            slideDirection = transform.right;
            isSliding = true;
        }
    }

    void FixedUpdate()
    {
        if (isSliding && rb != null)
        {
            // Apply sliding movement by modifying Rigidbody velocity
            rb.velocity = slideDirection * slideSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Stop sliding when colliding with objects tagged "Obstacle" or "Barrier"
        if (collision.collider.CompareTag("Obstacles") || collision.collider.CompareTag("Barrier"))
        {
            Debug.Log("Collided with obstacle or barrier. Stopping slide.");
            isSliding = false;

            // Stop the Rigidbody's movement
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
