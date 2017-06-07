using UnityEngine;
using UnityEngine.UI;
using System;

public class plusLittleOmega : MonoBehaviour{
    public InputField perigee;
    public static double ToDouble(string value) { return 0; }
	private double perigeedouble;
	public  ResetButton reset;
	public PauseButton pause;
	public Library lib;
	
    public void addlitOmega(){
        perigeedouble = Convert.ToDouble(lib.getP());
        if(perigeedouble == 360.00){
            perigeedouble = 5.00;
            perigee.text = perigeedouble.ToString("N2");
        }
        else if(perigeedouble >= 355.00){
            perigeedouble = 360.00;
            perigee.text = perigeedouble.ToString("N2");
        }
        else if (perigee.text == "undef"){

        }
        else{
            perigeedouble += 5.00;
            perigee.text = perigeedouble.ToString("N2");
        }
        if(pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
