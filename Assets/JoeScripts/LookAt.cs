using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookAt : MonoBehaviour
{
    public Transform playerCamera;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera);
    }
}
