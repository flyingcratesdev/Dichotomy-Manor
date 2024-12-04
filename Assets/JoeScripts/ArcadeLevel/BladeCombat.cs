using System.Collections;
using UnityEditor;
using UnityEngine;

public class BladeCombat : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public int layerIndex = 0; // Animator layer index (default is 0)
    public bool inAction = false;
    public GameObject hitbox;
    public float knockbackForce = 10f; // The intensity of the knockback
    public float knockbackDuration = 0.5f; // How long the knockback lasts
    [SerializeField]
    private CharacterController characterController;
    private Vector3 knockbackVelocity; // Stores the current knockback velocity
    private float knockbackTime = 0f; // Timer for knockback duration


    private IEnumerator PlayAndWaitForAnimation(string stateName)
    {
        inAction = true;
        if (animator == null)
        {
            Debug.LogError("Animator is not assigned!");
            yield break;
        }

        // Trigger the animation
        animator.Play(stateName, layerIndex);

        // Wait until the animator enters the specified state
        while (!animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
        {
            yield return null;
        }

        // Get the animation state info
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        // Wait for the animation to finish
        float animationLength = stateInfo.length;
        yield return new WaitForSeconds(animationLength);
        inAction = false;
            
        Debug.Log($"Animation '{stateName}' completed.");
    }
    private IEnumerator AttackHit()
    {


        yield return new WaitForSeconds(0.5f);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hitbox.SetActive(false);




    }
    void Update()
    {
        if (knockbackTime > 0)
        {
            characterController.Move(knockbackVelocity * Time.deltaTime);

            // Decrease knockback time
            knockbackTime -= Time.deltaTime;

            // Gradually reduce the knockback velocity to create a smooth stop
            knockbackVelocity = Vector3.Lerp(knockbackVelocity, Vector3.zero, Time.deltaTime / knockbackDuration);
        }

        if (!inAction)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               

                StartCoroutine(PlayAndWaitForAnimation("SwordSlash"));
                StartCoroutine(AttackHit());
                
            }
            else if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine(PlayAndWaitForAnimation("SwordBlock"));



            }
            {
                animator.Play("SwordIdle");
            }



        }
        else
        {

           


        }
    }
    public void ApplyKnockback(Vector3 direction)
    {
        // Normalize the direction and scale by the knockback force
        knockbackVelocity = direction.normalized * knockbackForce;

        // Reset the knockback timer
        knockbackTime = knockbackDuration;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GuardHitBox>()) {
        ApplyKnockback(other.transform.position);
        
        }
    }
}
