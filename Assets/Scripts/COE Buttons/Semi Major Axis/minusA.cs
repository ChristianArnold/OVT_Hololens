using UnityEngine;
using UnityEngine.UI;
using System;

public class minusA : MonoBehaviour{
    public InputField semimajor;
	private double semimajordouble;
    public static double ToDouble(string value) { return 0; }
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
    public void subA(){
        semimajordouble = Convert.ToDouble(lib.getA()*290f);
        if (semimajordouble <= 6478.137){//min is 6378.137- radius of Earth
            lib.setA(6478.137);
        }
        else{
            lib.setA(semimajordouble - 100.000);
        }
        if (pause.clicks == 1){}
        else{
			reset.onButtonClick();
        }
    }
}
