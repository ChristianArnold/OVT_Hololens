using UnityEngine;
using UnityEngine.UI;
using System;

public class textBoxLittleOmega : MonoBehaviour
{
    public double value = 90.0;
    public InputField textBox;
    private static double ToDouble(string value) { return 0; }
	
	private string newText, eccentricitytext, inclinationtext;
	private double newValue, etoCompare, itoCompare;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
	public Text eT, iT;

    void Start()
    {
        lib.setP(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        newText = textBox.text;
        newValue = 90.0;

        try
        {
            if (lib.checkP())
            {
                newValue = Convert.ToDouble(newText);
            }
        }
        #pragma warning disable 0168
        catch (Exception e){}
		#pragma warning restore 0168

        if (newValue < 0.00)
        {
            newValue = 0;
            lib.setP(newValue);
        }
        else if (newValue > 360.00)
        {
            newValue = 360;
            lib.setP(newValue);
        }
        else
        {
            lib.setP(newValue);
        }
        etoCompare = 90.00;

        eccentricitytext = eT.text;
        if (eccentricitytext != lib.undef)
        {
            etoCompare = Convert.ToDouble(eccentricitytext);
        }

        itoCompare = 90.00;
        inclinationtext = iT.text;
        if (inclinationtext != lib.undef)
        {
            itoCompare = Convert.ToDouble(inclinationtext);
        }
        

        if (etoCompare == 0.000)
        {
            lib.setPundef();
        }
        if (etoCompare == 0 && itoCompare == 0 || etoCompare == 0 && itoCompare == 180)
        {
            lib.setPundef();
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
            GameObject.Find("bigOmega").GetComponent<textBoxBigOmega>().textBox.text = lib.undef;
        }
        
        if (pause.clicks == 1){}
        else
        {
            reset.onButtonClick();
        }
    }
}
