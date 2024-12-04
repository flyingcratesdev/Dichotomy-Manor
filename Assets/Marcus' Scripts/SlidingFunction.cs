using UnityEngine;

public class SlidingFunction : MonoBehaviour
{
    public CharacterController controller; // Reference to CharacterController
    public float slideSpeed = 5f; // Speed of sliding
    private Vector3 slideDirection; // Direction of sliding
    private bool isSliding = false; // Whether the player is currently sliding
    [SerializeField]
    private bool isOnIce = false;

    void Update()
    {
        // Call the sliding function only if the player is not already sliding
        if (!isSliding && isOnIce)
        {
            HandleSliding();
        }
    }

    // Function to handle the sliding logic
    void HandleSliding()
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
        // Move the player in the chosen direction if sliding
        if (isSliding && isOnIce)
        {
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
        }
    }

    // Stop sliding when colliding with objects tagged "Obstacle" or "Barrier"
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacles") || hit.collider.CompareTag("Barrier")) 
        {
            Debug.Log("Collided with obstacle or barrier or key. Stopping slide.");
            isSliding = false; // Allow new input after stopping
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ice")) {
        isOnIce = true;
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            isOnIce = false;

        }
    }
}
