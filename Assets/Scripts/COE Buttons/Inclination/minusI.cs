using UnityEngine;
using UnityEngine.UI;
using System;

public class minusI : MonoBehaviour{
    public InputField inclination;
    public static double ToDouble(string value) { return 0; }
	private string eccentricitytext;
	private double inclinationdouble, etoCompare;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
    public void subI(){
        inclinationdouble = Convert.ToDouble(lib.getI());
        if (inclinationdouble <= 5.00){
            inclinationdouble = 0.00;
            lib.setI(inclinationdouble);
        }
        else{
            inclinationdouble -= 5.00;
            lib.setI(inclinationdouble);
        }
        etoCompare = 90.00;
        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        if (eccentricitytext != lib.undef){
            etoCompare = Convert.ToDouble(eccentricitytext);
        }
        if (inclinationdouble == 0.00 && etoCompare != 0){
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "Π";
            lib.setRundef();
        }
        else{
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
        }
        if (etoCompare == 0 && inclinationdouble == 0){
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
            lib.setPundef();
            lib.setRundef();
        }
        if (GameObject.Find("bigOmega").GetComponent<textBoxBigOmega>().textBox.text == lib.undef && inclinationdouble == 175){
            lib.setR(90.00);
        }
        if (pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
