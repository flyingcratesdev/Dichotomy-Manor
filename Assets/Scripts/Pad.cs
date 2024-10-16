using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{

    public MeshRenderer render;
    public Material red, green, grey;
    public bool isTriggered = false;
    public bool isCorrect = false;


    private void Start()
    {
        render = GetComponent<MeshRenderer>();  
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isTriggered)
        {
            if(isCorrect)
            {

                render.material = green;

            }else
            {
                render.material = red;
               other.GetComponentInParent<FPSController>().SetLocation(new Vector3(-45, 1.5f, 32));


            }
           // Invoke("ResetColor", 3f);
            isTriggered = false;
        }
    }
    void ResetColor()
    {
        render.material = grey;

    }
}
