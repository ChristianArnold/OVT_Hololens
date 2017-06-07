using UnityEngine;
using UnityEngine.UI;
using System;

public class minusBigOmega : MonoBehaviour{
    public InputField raan;
    public static double ToDouble(string value) { return 0; }
	private double raandouble;
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
    public void subBigOmega(){
        raandouble = Convert.ToDouble(lib.getR());
        if (raan.text == "undef")
        {

        }
        else if ((raandouble-5) < 0){
            lib.setR(355.0);
        }
        else if (raandouble <= 5.00){
            lib.setR(0);
        }
        else{
            lib.setR(raandouble-5.0);
        }
        if (pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
