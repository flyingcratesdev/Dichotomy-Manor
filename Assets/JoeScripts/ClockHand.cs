using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public Transform rotateHand;
    public ClockManager manager;
    public int big, small;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void RotateHand()
    {

        rotateHand.Rotate(0, 30, 0);
        manager.AddSmall(small);
        manager.AddBig(big);
    }
}
