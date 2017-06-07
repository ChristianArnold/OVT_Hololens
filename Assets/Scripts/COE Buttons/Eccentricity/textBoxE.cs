using UnityEngine;
using UnityEngine.UI;
using System;

public class textBoxE : MonoBehaviour
{
    public double value = 0.01;
    public InputField textBox;
    private static double ToDouble(string value) { return 0; }
	
	private string newText, eccentricitytext, inclinationtext;
	private double newValue, etoCompare, itoCompare;
	
	
	public  ResetButton reset;
	public PauseButton pause;
	public Library lib;
	
    void Start(){
        lib.setE(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        newText = textBox.text;
        newValue = 0.01;

        try
        {
            newValue = Convert.ToDouble(newText);
        }
        #pragma warning disable 0168
        catch (Exception e){}
		#pragma warning restore 0168

        if (newValue < 0.00)
        {
            newValue = 0;
            lib.setE(newValue);
        }
        else if (newValue > 0.999)
        {
            newValue = 0.999;
            lib.setE(newValue);
        }
        else
        {
            lib.setE(newValue);
        }

        etoCompare = 90.00;

        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        if (eccentricitytext != lib.undef)
        {
            etoCompare = Convert.ToDouble(eccentricitytext);
        }

        itoCompare = 90.00;
        inclinationtext = GameObject.Find("i").GetComponent<textBoxI>().textBox.text;
        if (inclinationtext != lib.undef)
        {
            itoCompare = Convert.ToDouble(inclinationtext);
        }

        if (itoCompare == 0.00 && etoCompare != 0)
        {
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "Π";
            lib.setRundef();
        }
        else
        {
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
        }

        if (etoCompare == 0 && itoCompare != 0)
        {
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "u";
            lib.setPundef();
        }
        else
        {
            if (GameObject.Find("littleOmega").GetComponent<textBoxLittleOmega>().textBox.text == lib.undef)
            {
                lib.setP(90.00);
            }
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "v";
        }

        if (etoCompare == 0 && itoCompare == 0 || etoCompare == 0 && itoCompare == 180)
        {
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
            lib.setPundef();
			lib.setRundef();
        }

        if (pause.clicks == 1)
        {

        }
        else
        {
            reset.onButtonClick();
        }
    }
}
