using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class MinusButton : MonoBehaviour
{
	public InputField percent;
	public clockScript clock;
    public void onButtonClick()
    {
        if (clock.multiplier > 50 && clock.multiplier <= 200)
        {

            clock.multiplier -= 10;

            percent.text = clock.multiplier.ToString();

        }
        else
        {

            if ((clock.multiplier - 2) < 2)
            {
                clock.multiplier = 1;

                percent.text = clock.multiplier.ToString();
            }
            else
            {
                clock.multiplier -= 2;

                percent.text = clock.multiplier.ToString();

            }
        }

    }

}
