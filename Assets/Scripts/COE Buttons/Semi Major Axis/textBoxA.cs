using UnityEngine;
using UnityEngine.UI;
using System;

public class textBoxA : MonoBehaviour
{
    public double value = 10000.00;
    public InputField textBox;
    private static double ToDouble(string value) { return 0; }
	private string newText;
	private double newValue;
	
	public ResetButton reset;
	public PauseButton pause;
	public Library lib;
	void Start(){
		lib.setA(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
	}
    public void ValueChangeCheck(){
        newText = textBox.text;
        newValue = 10000;

        try{
            newValue = Convert.ToDouble(newText);
        }
		#pragma warning disable 0168
        catch(Exception e){}
		#pragma warning restore 0168
        if (newValue <= 6378.137){
            lib.setA(6378.137);
        }
        else if(newValue > 384372.282){
            lib.setA(384372.281);
        }
        else{
            lib.setA(newValue);
        }
        if(pause.clicks == 1){}
        else{
            reset.onButtonClick();
        }
    }
}
