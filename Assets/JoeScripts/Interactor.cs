using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public LayerMask layerMask;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.collider.GetComponent<ClockHand>() && Input.GetKeyDown(KeyCode.Mouse0))
            {

                hit.collider.GetComponent<ClockHand>().RotateHand();
            }


        }

      



    }

}
