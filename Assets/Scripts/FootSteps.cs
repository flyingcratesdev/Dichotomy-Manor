using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footsteps;
    public AudioSource sprint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            footsteps.enabled = true;
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                footsteps.enabled = false;
                sprint.enabled = true;
            }
            else
            {
                footsteps.enabled = true;
                sprint.enabled = false;
            }
        }
        else
        {
            footsteps.enabled = false;
            sprint.enabled = false;
        }
    }
}
