using UnityEngine;
using UnityEngine.UI;
using System;

public class textBoxI : MonoBehaviour
{
    public double value = 45.0;
    public InputField textBox;
    private static double ToDouble(string value) { return 0; }
	
	private string newText, eccentricitytext, inclinationtext;
	private double newValue, etoCompare, itoCompare;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
	void Start(){
		lib.setI(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
	}

    public void ValueChangeCheck()
    {
        newText = textBox.text;
        newValue = 45.0;

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
            lib.setI(newValue);
        }
        else if (newValue > 180.00)
        {
            newValue = 180;
            lib.setI(newValue);
        }
        else
        {
            lib.setI(newValue);
        }
        etoCompare = 90.00;

        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        if (eccentricitytext != lib.undef)
        {
            etoCompare = Convert.ToDouble(eccentricitytext);
        }

        if (newValue == 0.00 && etoCompare != 0)
        {
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "Π";
            lib.setRundef();
        }
        else
        {
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
            if (GameObject.Find("bigOmega").GetComponent<textBoxBigOmega>().textBox.text == lib.undef){
                lib.setR(90.0);
            }
            
        }

        if (etoCompare == 0 && newValue == 0 || etoCompare == 0 && newValue == 180)
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
