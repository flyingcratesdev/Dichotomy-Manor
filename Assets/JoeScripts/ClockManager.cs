using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{

    public int smallHand = 3;
    public int bigHand = 12;
    public int sum;
    public TMP_Text clockText;
    void Start()
    {
        clockText.text = "" + smallHand + " + " + bigHand + " = " + "19";
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddSmall(int a)
    {
       
        smallHand += a;
        if (smallHand > 12)
        {
            smallHand = 1;

        }
        sum = smallHand + bigHand;
        clockText.text = "" + smallHand + " + " + bigHand + " = " + "19";
        if(sum == 19)
        {

            clockText.color = Color.green;
        }
        else
        {

            clockText.color = Color.white;

        }

    }  public void AddBig(int a)
    {
        bigHand += a;
        if (bigHand > 12)
        {
            bigHand = 1;

        }
        sum = smallHand + bigHand;

        clockText.text = "" + smallHand + " + " + bigHand + " = " + "19";
        if (sum == 19)
        {

            clockText.color = Color.green;
        }else
        {

            clockText.color = Color.white;

        }

    }
}
