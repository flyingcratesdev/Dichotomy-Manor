using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockManager : MonoBehaviour
{

    public int num1, num2, num3, num4, num5;
    public string currentGuess;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SendNum(int num, int lockNum)
    {


        switch(num)
        {
            case 0:
                num1 = lockNum;
                break;

            case 1:
                num2 = lockNum;
                break;

            case 2:
                num3 = lockNum;
                break;

            case 3:
                num4 = lockNum;
                break;

            case 4:
                num5 = lockNum;
                break;

        }
        currentGuess = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString() + num5.ToString();


    }
}
