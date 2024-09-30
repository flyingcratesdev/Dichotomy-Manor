using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{

    public LayerMask layerMask;
    public List<int> listInventory;
    public List<GameObject> slotsGameObjects;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    for (int i = 0; i < listInventory.Count; i++)
                    {

                        if(i == 0)
                        {


                        }
                    }

                    
                }




            }

        }
    }



}



