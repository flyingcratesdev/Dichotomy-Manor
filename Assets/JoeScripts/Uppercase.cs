using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uppercase : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputField.text != null)
        {
            inputField.text = inputField.text.ToUpper();


        }
    }
}
