using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class PlusSpeed : MonoBehaviour {
	
	public InputField percent;
	public clockScript clock;
	// Use this for initialization
    public void onButtonClick()
    {
	if (clock.multiplier >= 50)
        {

            if ((clock.multiplier + 10) >= 200)
            {
                clock.multiplier = 200;
                percent.text = clock.multiplier.ToString();
            }
            else
            {
                clock.multiplier += 10;

                percent.text = clock.multiplier.ToString();

            }
        }
        else
        {
            if ((clock.multiplier + 2) >= 200)
            {
                clock.multiplier = 200;

                percent.text = clock.multiplier.ToString();
            }
            else
            {
                clock.multiplier += 2;

                percent.text = clock.multiplier.ToString();

            }
        }
    }
}
