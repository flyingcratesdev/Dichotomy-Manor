using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    public TargetManager manager;
    public Transform from;
    public Transform to;
    public Transform pivot;
    private float timeCount = 0.0f;
    public int numId = 0;
    public bool isHit = false;
    public bool isReset = false;
    bool knocked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            pivot.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
            if (timeCount >= 1)
            {

                isHit = false;
                timeCount = 0;
            }
        }
        if(isReset)
        {
            pivot.rotation = Quaternion.Slerp(to.rotation, from.rotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
            if(timeCount >= 1)
            {

                isReset = false;
                timeCount = 0; 
            }
        }
       
    }


    public void HitTarget()
    {
        if (!isReset && !knocked)
        {

            if (!isHit)
            {
                Invoke("ResetTarget", 4);
                isHit = true;
                knocked = true;
                manager.AddNum(numId);


            }
        }
    }
    void ResetTarget()
    {
        knocked = false;

        isReset = true;
    }
}
