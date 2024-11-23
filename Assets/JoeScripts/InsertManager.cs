using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertManager : MonoBehaviour
{
    bool isRed = false;
    bool isBlue = false;

    public GameObject uncompleted, completed;

    public void SetBlock(bool isred)
    {
        if(isred)
        {

            isRed = true;


        }else
        {

            isBlue = true;
        }
        if (isRed && isBlue)
        {

            uncompleted.SetActive(false);
            completed.SetActive(true);
            

        }


    }




}
