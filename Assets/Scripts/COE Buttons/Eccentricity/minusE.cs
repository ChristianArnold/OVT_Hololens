using UnityEngine;
using UnityEngine.UI;
using System;

public class minusE : MonoBehaviour{
    public InputField eccent;
    public static double ToDouble(string value) { return 0; }
	private string eccentricitytext, inclinationtext;
	private double eccentdouble, etoCompare, itoCompare;
	
	public  ResetButton reset;
	public PauseButton pause;
	public Library lib;
	
	
    public void subE(){
        eccentdouble = Convert.ToDouble(lib.getE());
        if(eccentdouble <= 0.100){
            eccentdouble = 0.000;
            lib.setE(eccentdouble);
        }
        else{
            eccentdouble -= 0.100;
            lib.setE(eccentdouble);
        }
        etoCompare = 90.00;
        eccentricitytext = GameObject.Find("e").GetComponent<textBoxE>().textBox.text;
        if(eccentricitytext != lib.undef){
            etoCompare = Convert.ToDouble(eccentricitytext);
        }
        itoCompare = 90.00;
        inclinationtext = GameObject.Find("i").GetComponent<textBoxI>().textBox.text;
        if(inclinationtext != lib.undef){
            itoCompare = Convert.ToDouble(inclinationtext);
        }
        if(itoCompare == 0.00 && etoCompare != 0){
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "Π";
            lib.setRundef();
        }
        else{
            GameObject.Find("argumentOfPerigeePackage").GetComponent<Text>().text = "ω";
        }
        if(etoCompare == 0 && itoCompare != 0){
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "u";
            lib.setPundef();
        }
        else{
            lib.setP(90.00);
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "v";
        }
        if(etoCompare == 0 && itoCompare == 0 || etoCompare == 0 && itoCompare == 180){
            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
            lib.setPundef();
			lib.setRundef();
        }
        if(pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
