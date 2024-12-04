using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combination : MonoBehaviour
{
    public FPSController Controller;
    public bool isOnTrigger = false;
    public bool isDoorTriggered = false;
    public GameObject InputField;
    public GameObject Door;
    public TMP_InputField field;
    bool isDisabled = false;
    public string Answer = "936";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisabled)
        {
            if (isOnTrigger && Input.GetKeyDown(KeyCode.E) && !isDoorTriggered)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Controller.enabled = false;
                isDoorTriggered = true;
                InputField.SetActive(true);

            }
            else if (isOnTrigger && Input.GetKeyDown(KeyCode.Tab) && isDoorTriggered)
            {

                Controller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                InputField.SetActive(false);

                isDoorTriggered = false;

            }
        }
        if (isDoorTriggered)
        {
            if (field.text == Answer && Input.GetKeyDown(KeyCode.Return))
            {

                field.text = "";
                Door.SetActive(false);
                Controller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                InputField.SetActive(false);
                isDisabled = true;
                isDoorTriggered = false;

            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {

                field.text = "";


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPSController>())
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FPSController>())
        {
            isOnTrigger = false;
        }
    }
}
