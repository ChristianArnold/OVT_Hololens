using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RIScript : MonoBehaviour {
    public InputField iRadF;
    private Vector3 pos;
	private string newText;
	private double newValue;
	
	public Library lib;
    void Start(){
        iRadF.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }
    void Update(){
        pos = 29 * OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), lib.getN());
        iRadF.text = (-pos.z).ToString();
    }
    public void ValueChangeCheck(){
        newText = iRadF.text;
        newValue = 45.0f;

        try { newValue = Convert.ToDouble(newText); }
		#pragma warning disable 0168
        catch (Exception e){}
		#pragma warning restore 0168
		
        iRadF.text = newValue.ToString("N2");
    }
}
