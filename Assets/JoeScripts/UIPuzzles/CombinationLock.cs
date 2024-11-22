using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CombinationLock : MonoBehaviour
{

    public int lockOrder = 0;
    public int lockNum = 0;
    public TMP_Text textLock;
    public CombinationLockManager manager;
    void Start()
    {
        manager.SendNum(lockOrder, lockNum);

    }

    public void ButtonPressed()
    {

        if (lockNum < 9)
        {
            lockNum++;
        }else
        {
            lockNum = 0;


        }
        textLock.text = "" + lockNum;
        manager.SendNum(lockOrder, lockNum);


    }
}
