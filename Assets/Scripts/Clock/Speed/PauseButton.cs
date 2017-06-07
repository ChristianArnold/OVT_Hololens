using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class PauseButton : MonoBehaviour
{
    public Text pauseText;
    public int clicks = 0;

    public SatelliteOrbit scriptSO;
    public EarthRotation scriptER;
    public textBoxNu scriptTBN;
    public clockScript scriptCS;
    public RKScript scriptRK;
    public RIScript scriptRI;
    public RJScript scriptRJ;
    public VKScript scriptVK;
    public VIScript scriptVI;
    public VJScript scriptVJ;
    public textBoxNu TBN;

    public Library lib;
    public GameObject rvPackage;
    public rVScript rvS;
    public SatelliteOrbit satOrbit;
    void Update()
    {
        if (clicks == 0 && TBN.editing == false)
        {
            if (rvS.mouseClicks == 1)
            {
                scriptRK.enabled = true;
                scriptRI.enabled = true;
                scriptRJ.enabled = true;
                scriptVK.enabled = true;
                scriptVI.enabled = true;
                scriptVJ.enabled = true;
            }
            scriptSO.enabled = true;
            scriptER.enabled = true;
            scriptTBN.enabled = true;
            scriptCS.enabled = true;
        }
    }

    public void onButtonClick()
    {
        if (rvS.mouseClicks == 1)
        {
            scriptRK.enabled = !scriptRK.enabled;
            scriptRI.enabled = !scriptRI.enabled;
            scriptRJ.enabled = !scriptRJ.enabled;
            scriptVK.enabled = !scriptVK.enabled;
            scriptVI.enabled = !scriptVI.enabled;
            scriptVJ.enabled = !scriptVJ.enabled;
        }

        scriptSO.enabled = !scriptSO.enabled;
        scriptER.enabled = !scriptER.enabled;
        scriptCS.enabled = !scriptCS.enabled;

        clicks = clicks + 1;

        if (clicks == 1)
        {
            pauseText.text = lib.play;
        }
        else if (clicks == 2)
        {
            clicks = 0;
            pauseText.text = lib.pause;
        }
    }
}

