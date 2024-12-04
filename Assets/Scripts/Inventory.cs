using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public GameObject bookUI;
    public TMP_Text bookText;
    public TMP_Text bookTextTwo;
    public FPSController controllerScript;
    int bookIndex = 0;
    public Animator anim;

    bool isSwinging = false;


    private void Start()
    {
        SetSelector(0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            controllerScript.canMove = true;

            bookUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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

            if (itemInHand.nameItem.Equals("crowbar"))
            {
                if (!isSwinging)
                {
                    anim.Play("CrowBarIdle");

                }
                else
                {
                    anim.Play("CrowBarSwing");



                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && !isSwinging)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f, gunMask))
                    {
                     if(hit.collider.GetComponent<Crate>())
                        {

                            Destroy(hit.collider.gameObject);
                        }

                    }
                    Invoke("ResetAnimation", 1f);
                    isSwinging = true;

                }



            }
            else if (itemInHand.nameItem.Equals("gun") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("using gun");
                RaycastHit hit;
                // PickUp Item
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, gunMask))
                {
                    if (hit.collider.GetComponent<TargetDummy>())
                    {
                        hit.collider.GetComponent<TargetDummy>().HitTarget();

                    }

                }

            }else if(itemInHand.nameItem.Equals("redpuzzlecube") && Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                // PickUp Item
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, gunMask))
                {
                    if (hit.collider.GetComponent<InsertRed>())
                    {
                        hit.collider.GetComponent<InsertRed>().InsertBlock();
                        DestroyItem();

                    }

                }


            }
            else if (itemInHand.nameItem.Equals("bluepuzzlecube") && Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                // PickUp Item
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, gunMask))
                {
                    print(hit.collider.gameObject);
                    if (hit.collider.GetComponent<InsertBlue>())
                    {
                        hit.collider.GetComponent<InsertBlue>().InsertBlock();
                        DestroyItem();
                    }

                }


            }
            else
            {

                anim.Play("Default");


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

                            hit.collider.gameObject.layer = 9;
                            hit.collider.gameObject.transform.localPosition = hit.collider.GetComponent<ItemHolder>().curItem.localPosition;
                            hit.collider.gameObject.transform.localEulerAngles = hit.collider.GetComponent<ItemHolder>().curItem.localRotation;
                            SetSelector(selectorID);
                            return;


                        }
                    }
                }
                if (hit.collider.GetComponent<Trigger>() && itemInHand)
                {


                    hit.collider.GetComponent<Trigger>().CheckKey(itemInHand.nameItem);
                    DestroyItem();






                }



            }

        }
    }
    void ResetAnimation()
    {

        isSwinging = false;


    }
    void DestroyItem()
    {
        listInventory[selectorID] = 0;
        listItems[selectorID] = null;
        slotsImages[selectorID].sprite = null;
        Destroy(slotsGameObjects[selectorID].transform.gameObject);
        SetSelector(selectorID);

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
        if (itemInHand != null)
        {
            if (itemInHand.isBook)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                bookIndex = 0;
                bookText.text = itemInHand.bookText[0];
                bookTextTwo.text = itemInHand.bookText[bookIndex + 1];

                bookUI.SetActive(true);
                controllerScript.canMove = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                bookUI.SetActive(false);
            controllerScript.canMove = true;


            }
        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            bookUI.SetActive(false);
            controllerScript.canMove = true;



        }



    }


    public void NextPage()
    {
        if(bookIndex < itemInHand.bookText.Length-2)
        {
            bookIndex += 2;
           bookText.text = itemInHand.bookText[bookIndex];
            bookTextTwo.text = itemInHand.bookText[bookIndex + 1];
        }

    }

    public void PrevPage()
    {
        if (bookIndex > 0)
        {
            bookIndex -= 2;
            bookText.text = itemInHand.bookText[bookIndex];
            bookTextTwo.text = itemInHand.bookText[bookIndex + 1];


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



