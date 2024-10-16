using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public string orderStr = "";
    public GameObject WinText;
    public float timer;
    void Start()
    {
        
    }

    void Update()
    {
        if(timer > 0)
        {

            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            orderStr = "";

        }
        if (orderStr == "1234")
        {

            print("you win");
            WinText.SetActive(true);

        }

    

    }
    public void AddNum(int num)
    {
        if (orderStr.Length == 4)
        {

            orderStr = "";

        }
        orderStr += num.ToString();
        timer = 4;
    }


}
