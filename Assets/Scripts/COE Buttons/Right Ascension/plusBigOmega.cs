using UnityEngine;
using UnityEngine.UI;
using System;

public class plusBigOmega : MonoBehaviour{
    public InputField raan;
    public static double ToDouble(string value) { return 0; }
	private double raandouble;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
    public void addBigOmega(){
        raandouble = Convert.ToDouble(lib.getR());
        if (raandouble == 360.00){
            raandouble = 0.00;
            lib.setR(raandouble);
        }
        else if (raandouble >= 355.00){
            raandouble = 0.00;
            lib.setR(raandouble);
        }
        else if (raan.text == "undef")
        {

        }
        else{
            raandouble += 5.00;
            lib.setR(raandouble);
        }
        if (pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
