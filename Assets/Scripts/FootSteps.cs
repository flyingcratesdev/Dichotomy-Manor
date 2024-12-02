using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public CharacterController player;
    public AudioSource source;
    public AudioClip footsteps;
    public AudioClip sprint;
    public float velocity;
    public bool isWalking;
    public bool isSprinting;

    // Update is called once per frame
    void Update()
    {
        velocity = player.velocity.sqrMagnitude;
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (velocity > 45)
        {
            source.clip = sprint;
            isSprinting = true;
            isWalking = false;
        }
        else if (velocity > 0)
        {
            source.clip = footsteps;

            isSprinting = false;
            isWalking = true;

        }
        else if (velocity == 0)
        {
            source.Stop();
            isSprinting = false;
            isWalking = false;

        }
    }
}
