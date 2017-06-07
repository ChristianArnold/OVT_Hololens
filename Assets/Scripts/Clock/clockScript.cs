using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class clockScript : MonoBehaviour
{

    public InputField hours, minutes, seconds;
    public int multiplier = 1;

    public int totalseconds = 0, relativehours = 0, relativemins = 0, relativeseconds = 0;

    void Update()
    {
        totalseconds = totalseconds + multiplier;
        totalseconds = totalseconds % int.MaxValue;

        if (totalseconds >= 60)
        {
            seconds.text = relativeseconds.ToString("N0");

            relativeseconds = totalseconds % 60;
            if (relativeseconds < 10)
            {
                seconds.text = "0" + relativeseconds.ToString("N0");
            }

            relativemins = (totalseconds / 60) % 60;
            minutes.text = relativemins.ToString("N0");

            if (relativemins < 10)
            {
                minutes.text = "0" + relativemins.ToString("N0");
            }


            if (totalseconds >= 3600)
            {
                relativehours = totalseconds / 3600;
                if (relativehours < 10)
                {
                    hours.text = "0" + relativehours.ToString("N0");
                }
                else
                {
                    hours.text = relativehours.ToString("N0");
                }
            }
            else
            {
                hours.text = "00";
            }
        }
        else
        {
            minutes.text = "00";
            if (totalseconds < 10)
            {
                seconds.text = "0" + seconds.ToString();
                seconds.text = totalseconds.ToString("N0");
            }
            else
            {
                seconds.text = totalseconds.ToString("N0");
            }
        }
    }
}
