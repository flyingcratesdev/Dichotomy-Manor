using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Safe : MonoBehaviour
{


    public FPSController Controller;
    public bool isOnTrigger = false;
    public bool isTriggered = false;
    public GameObject InputField;
    public GameObject SafeDoor;
    public TMP_InputField field;
    bool isDisabled = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!isDisabled)
        {
            if (isOnTrigger && Input.GetKeyDown(KeyCode.E) && !isTriggered)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Controller.enabled = false;
                isTriggered = true;
                InputField.SetActive(true);

            }
            else if (isOnTrigger && Input.GetKeyDown(KeyCode.E) && isTriggered)
            {

                Controller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                InputField.SetActive(false);

                isTriggered = false;

            }
        }
        if(field.text == "7126" && Input.GetKeyDown(KeyCode.Return))
        {

            field.text = "";
            SafeDoor.SetActive(false);
            Controller.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            InputField.SetActive(false);
            isDisabled = true;
            isTriggered = false;

        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {

            field.text = "";


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FPSController>())
        {
            isOnTrigger = true;   

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<FPSController>())
        {

            isOnTrigger = false;
        }
    }
}
