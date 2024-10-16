using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public LayerMask layerMask;
    public LayerMask gunMask;
    public List<int> listInventory;
    public List<Item> listItems;
    public List<Image> slotsImages;
    public List<GameObject> slotsGameObjects;
    public Transform selector;
    public int selectorID;
    public Transform hand;
    public Item itemInHand;

    private void Start()
    {
       SetSelector(0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            listInventory[selectorID] = 0;
            listItems[selectorID] = null;
            slotsImages[selectorID].sprite = null;
            slotsGameObjects[selectorID].transform.SetParent(null);

            slotsGameObjects[selectorID].GetComponent<Rigidbody>().useGravity = true;
            slotsGameObjects[selectorID].GetComponent<Rigidbody>().isKinematic = false;
            slotsGameObjects[selectorID].layer = 6;
            slotsGameObjects[selectorID] = null;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSelector(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSelector(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            SetSelector(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSelector(3);


        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSelector(4);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetSelector(5);


        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetSelector(6);


        }
        if (itemInHand != null)
        {
            if (itemInHand.nameItem.Equals("gun") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                // PickUp Item
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, gunMask))
                {
                    if (hit.collider.GetComponent<TargetDummy>())
                    {
                        hit.collider.GetComponent<TargetDummy>().HitTarget();

                    }

                }

            }
        }
            if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            // PickUp Item
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.GetComponent<ItemHolder>())
                {
                    for (int i = 0; i < listInventory.Count; i++)
                    {

                        if (listInventory[i] == 0)
                        {
                            listInventory[i] = 1;
                            slotsImages[i].sprite = hit.collider.GetComponent<ItemHolder>().curItem.visualItem;
                            listItems[i] = hit.collider.GetComponent<ItemHolder>().curItem;
                            slotsGameObjects[i] = hit.collider.gameObject;
                            hit.collider.gameObject.transform.SetParent(hand, false);
                            hit.collider.gameObject.transform.localEulerAngles = Vector3.zero;
                            hit.collider.GetComponent<Rigidbody>().useGravity = false;
                            hit.collider.GetComponent<Rigidbody>().isKinematic = true;

                            hit.collider.gameObject.layer = 0;
                            hit.collider.gameObject.transform.localPosition = Vector3.zero;
                            SetSelector(selectorID);
                            return;


                        }
                    }
                }
                if (hit.collider.GetComponent<Trigger>())
                {

                    if(itemInHand.nameItem.Equals("key"))
                    {

                        print("OpenDoor");

                    }else
                    {

                        print("Nothing happened");

                    }



                }



            }

        }
    }


    void SetSelector(int slotID)
    {
        selector.position = slotsImages[slotID].transform.position;
        selectorID = slotID;
        itemInHand = listItems[slotID];

        for (int i = 0;i < slotsGameObjects.Count;i++)
        {
            if (i == slotID)
            {
                if(slotsGameObjects[i] != null)
                slotsGameObjects[i].SetActive(true);
            }else
            {
                if (slotsGameObjects[i] != null)
                    slotsGameObjects[i].SetActive(false);


            }

        }



    }


    /*private void OnTriggerStay(Collider other)
    {


        if(other.GetComponent<Trigger>())
        {
            print("Standing in doorway");

            if (Input.GetKeyDown(KeyCode.E) && itemInHand.name == "key")
            print("Open the door");


        }
    }*/



}



