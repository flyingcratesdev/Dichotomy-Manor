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
    public float lockoutTime = 0;
    public Image middleSlider;
    public GameObject hatch;
    bool hasWon = false;
    // Start is called before the first frame update
    void Start()
    {
        visualSliderOne.value = minNum;
        visualSliderTwo.value = visualSliderTwo.maxValue - maxNum;


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !hasWon)
        {
            if (sliderValue > minNum && sliderValue < maxNum)
            {
                middleSlider.color = Color.green;
                hasWon = true;

                Destroy(hatch);
                print("You WIN");
            }
            else
            {
                middleSlider.color =Color.red;
                lockoutTime = 2;
                isLockedout = true;
                print("You LOSE");

            }

         

        }
        if (lockoutTime > 0)
        {
            lockoutTime -= Time.deltaTime;
        }
        else if (isLockedout)
        {
            middleSlider.color = Color.black;
            isLockedout = false;
        }
        if (!isLockedout && !hasWon)
        {
            if (!switchToNegative)
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
}
