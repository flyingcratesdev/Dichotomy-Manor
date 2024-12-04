using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InsertManager : MonoBehaviour
{
    public bool isRed = false;
    public bool isBlue = false;

    public GameObject uncompleted, completed;
    public SpawnKey roomDone;
    public void SetBlock(bool isred)
    {
        if(isred)
        {

            isRed = true;


        }else
        {
            isBlue = true;


        }
        if(isRed && isBlue)
        {

            roomDone.SetKeyActive();

        }



    }
    




}
