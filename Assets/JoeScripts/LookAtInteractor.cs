using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LookAtInteractor : MonoBehaviour
{

    public LayerMask lookMask;
    public GameObject interactPrompt;
  
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lookMask))
        {


            if (hit.collider.GetComponent<Radio>())
            {
                interactPrompt.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {

                    hit.collider.GetComponent<Radio>().PlayClip();

                }


            }else
            {

                interactPrompt.SetActive(false);

            }
        }
        else
        {
            interactPrompt.SetActive(false);

        }


    }
}
