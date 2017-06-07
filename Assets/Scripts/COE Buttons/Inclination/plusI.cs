using UnityEngine;
using UnityEngine.UI;
using System;

public class plusI : MonoBehaviour{
    public InputField inclination;
    public static double ToDouble(string value) { return 0; }
	private string eccentricitytext;
	private double inclinationdouble, etoCompare;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
    public void addI(){
        inclinationdouble = Convert.ToDouble(lib.getI());
        if (inclinationdouble >= 175.00){
            inclinationdouble = 180.00;
            lib.setI(inclinationdouble);
        }
        else{
            inclinationdouble = inclinationdouble + 5.00;
            lib.setI(inclinationdouble);
        }
        if (inclinationdouble > 0.00 && inclinationdouble != 180){
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
            lib.setR(90.0);
        }
        etoCompare = 90.00;
        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        if (eccentricitytext != lib.undef) etoCompare = Convert.ToDouble(eccentricitytext);
        if (etoCompare == 0 && inclinationdouble != 180){
			GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "u";
		}
        else if (etoCompare == 0 && (inclinationdouble == 180 || inclinationdouble==0)){
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
            lib.setPundef();
            lib.setRundef();
        }
        else{
			GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "v";
		}
        if (pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
