using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public string orderStr = "";
    public float timer;
    public SpawnKey roomDone;
    bool isComplete = false;
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
        if (orderStr == "1234" && !isComplete)
        {
            roomDone.SetKeyActive();
            print("you win");
            isComplete = true;

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
