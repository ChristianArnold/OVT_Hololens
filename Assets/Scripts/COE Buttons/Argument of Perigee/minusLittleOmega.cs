using UnityEngine;
using UnityEngine.UI;
using System;

public class minusLittleOmega : MonoBehaviour{
    public InputField perigee;
    public static double ToDouble(string value) { return 0; }
	private double perigeedouble; 
	public  ResetButton reset;
	public PauseButton pause;
	public Library lib;
	
    public void sublitOmega(){
        perigeedouble = Convert.ToDouble(lib.getP());
        if (perigee.text == "undef")
        {

        }
        else if (perigeedouble == 0)
        {
            perigeedouble = 355.0;
            lib.setP(perigeedouble);
        }
        else if (perigeedouble <= 5.00)
        {
            perigeedouble = 0.00;
            lib.setP(perigeedouble);
        }
        else
        {
            perigeedouble -= 5.00;
            lib.setP(perigeedouble);
        }
        if(pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
