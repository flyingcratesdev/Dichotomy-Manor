using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionTester : MonoBehaviour
{


    public float minNum;
    public float maxNum;
    public Slider visualSliderOne, visualSliderTwo, reactionSlider;
    public float sliderValue;
    bool switchToNegative = false;
    public float speed = 5;
    public bool isLockedout;
    
    // Start is called before the first frame update
    void Start()
    {
        visualSliderOne.value = minNum;
        visualSliderTwo.value = visualSliderTwo.maxValue - maxNum;


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sliderValue > minNum && sliderValue < maxNum)
            {

                print("You WIN");
            }
            else
            {

                print("You LOSE");

            }



        }
        if(!switchToNegative)
        {
            sliderValue += Time.deltaTime * speed;
            reactionSlider.value = sliderValue;
            if (sliderValue >= 100)
            {


                switchToNegative = true;
            }


        }
        else
        {
            sliderValue -= Time.deltaTime * speed;
            reactionSlider.value = sliderValue;
            if (sliderValue <= 0)
            {


                switchToNegative = false;
            }
        }
    }
}
