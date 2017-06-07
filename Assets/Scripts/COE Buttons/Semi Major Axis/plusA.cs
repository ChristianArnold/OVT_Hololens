using UnityEngine;
using UnityEngine.UI;
using System;

public class plusA : MonoBehaviour{
    public InputField semimajor;
	private double semimajordouble;
	public static double ToDouble(string value) { return 0; }
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
	public void addA(){
        semimajordouble = Convert.ToDouble(lib.getA()*290f);
        if (semimajordouble >= 384372.281){//max is 384472.282
            lib.setA(semimajordouble);
        }
        else{
            lib.setA(semimajordouble + 100.000);
        }
        if (pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
