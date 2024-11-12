using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float turnSmoothtime = 0.1f;
    private float turnSmoothVelocity;

    public float speed = 6f;
    public float slipperyFactor = 0.95f; // Adjust for more or less sliding (0.9-0.99 for noticeable sliding)
    private Vector3 velocity;
    private bool isOnIce = false;

    // Update is called once per frame
    void Update()
    {
        CheckIfOnIce(); // Check if we are on an ice surface

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle for rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate the movement direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply sliding effect if on ice
            if (isOnIce)
            {
                // Reduce speed gradually to create a sliding effect
                velocity = moveDir.normalized * speed * slipperyFactor + velocity * slipperyFactor;
            }
            else
            {
                // Normal movement without sliding
                velocity = moveDir.normalized * speed;
            }

            // Move the character
            controller.Move(velocity * Time.deltaTime);
        }
        else if (isOnIce)
        {
            // If no input and on ice, continue sliding
            velocity *= slipperyFactor;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    // Method to check if the player is on an ice surface
    private void CheckIfOnIce()
    {
        RaycastHit hit;
        // Raycast downwards to check if the player is standing on an "Ice" tagged object
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            if (hit.collider.CompareTag("Ice"))
            {
                isOnIce = true;
            }
            else
            {
                isOnIce = false;
            }
        }
    }
}
