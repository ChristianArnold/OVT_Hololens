using UnityEngine;
using UnityEngine.UI;
using System;

public class textBoxBigOmega : MonoBehaviour
{
    public double value = 90.0;
    public InputField textBox;
    private static double ToDouble(string value) { return 0; }

	private string eccentricitytext, newText, inclinationtext;
	private double itoCompare, etoCompare, newValue;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
	void Start(){
		lib.setR(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
	}

    public void ValueChangeCheck()
    {
        newText = textBox.text;
        newValue = 90.0;

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
            lib.setR(newValue);
        }
        else if (newValue > 360.00)
        {
            newValue = 360;
            lib.setR(newValue);
        }
        else
        {
            lib.setR(newValue);
        }

        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        etoCompare = Convert.ToDouble(eccentricitytext);
        inclinationtext = GameObject.Find("i").GetComponent<textBoxI>().textBox.text;
        itoCompare = Convert.ToDouble(inclinationtext);

        if (etoCompare == 0 && itoCompare == 0)
        {
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
