using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text;

public class Library : MonoBehaviour{
	private float dA=10000.0f, dE=.01f, dI=45.0f, dR=90.0f, dP=90.0f, dN=0.0f;
	public float PI=Mathf.PI;
	public InputField aT, eT, iT, rT, pT, nT;
	
	public string vectorsOn, vectorsOff, rvOn, rvOff, undef, play, pause;
	
	/*called once before start, even if script component is not active
	  called only once. Ever.*/
	void Awake(){
		PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
		PlayerPrefs.SetInt("Screenmanager Resolution Height", 500);
		PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
		Application.targetFrameRate=60;
	}
	
	//Use this for initialization
	void Start(){
		vectorsOn="Turn Vectors On";vectorsOff="Turn Vectors Off"; 
		rvOn="R&V Inputs On"; rvOff="R&V Inputs off";
		undef="undef"; play="Play"; pause="Pause";
	}
	// Update is called once per frame
	void Update(){}
	//Called on Quit
	void OnApplicationQuit(){
		PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
		PlayerPrefs.SetInt("Screenmanager Resolution Height", 500);
		PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
		Application.targetFrameRate=60;
	}
	
	/**
	checks if semi-major axis textbox has valid input (not text, not too big/small, etc)
	returns textField/290 or dA/290
	**/
	public float getA(){
		if(checkA()){
			if(Mathf.Abs(float.Parse(aT.text)) <= 384372.282f && Mathf.Abs(float.Parse(aT.text)) > 6378.137f)
				return Mathf.Abs(float.Parse(aT.text))/290.0f;
			else if(Mathf.Abs(float.Parse(aT.text)) > 384372.282f)
				return 384372.282f/290.0f;
			else
				return 6378.137f/290.0f;
		}
		return dA/290.0f;
	}
	public bool checkA(){
		if(aT.text!="" && aT.text!= "0" && aT.text!="-" && aT.text!="-0" && aT.text!=".")
			return true;
		return false;
	}
	public void setA(double x){
		aT.text=x.ToString("N3");
	}
	
	public float getE(){
		if(checkE()){
			if (Mathf.Abs(float.Parse(eT.text)) < 1)
                return Mathf.Abs(float.Parse(eT.text));
            else
                return dE;
		}
		return dE;
	}
	public bool checkE(){
		if(eT.text != "" && eT.text != "-" && eT.text != ".") return true;
		return false;
	}
	public void setE(double x){
		eT.text=x.ToString("N3");
	}
	
	public float getI(){
		if(checkI()){
			if(Mathf.Abs(float.Parse(iT.text))>=180) return 180.0f;
			else if(Mathf.Abs(float.Parse(iT.text))<=0) return 0.0f;
			else return Mathf.Abs(float.Parse(iT.text));
		}
		return dI;
	}
	public bool checkI(){
		if (iT.text != "" && iT.text != "-" && iT.text != ".")return true;
		return false;
	}
	public void setI(double x){
		iT.text=x.ToString("N2");
	}
	
	public float getR(){
		if(checkR()) return Mathf.Abs(float.Parse(rT.text));
		else if(rT.text=="undef") return 0.0f;
		return dR;
	}
	public bool checkR(){
		if (rT.text!="" && rT.text!= "0" && rT.text!="-" && rT.text!="-0" && rT.text!="." && rT.text!= "undef"){
			if (Mathf.Abs(float.Parse(rT.text)) <= 360) return true;
			else return false;
		}
		return false;
	}
	public bool getrUndef(){
		return rT.text=="undef";
	}
	public void setR(double x){
		rT.text=x.ToString("N2");
	}
	public void setRundef(){
		rT.text=undef;
	}
	
	public float getP(){
		if(checkP()) 
			return Mathf.Abs(float.Parse(pT.text));
		else if(pT.text=="undef") return 0.0f;
		return dP;
	}
	public bool checkP(){
		if(pT.text!="" && pT.text!= "0" && pT.text!="-" && pT.text!="-0" && pT.text!="." && pT.text!="undef")
			if(Mathf.Abs(float.Parse(pT.text)) <= 360) return true;
		return false;
	}
	public bool getpUndef(){
		return pT.text=="undef";
	}
	public void setP(double x){
		pT.text=x.ToString("N2");
	}
	public void setPundef(){
		pT.text=undef;
	}
	
	public float getN(){
		if(checkN())
			if(Mathf.Abs(float.Parse(nT.text))<=360.0f && Mathf.Abs(float.Parse(nT.text))>=0.0f)
				return Mathf.Abs(float.Parse(nT.text));
		return dN;
	}
	public bool checkN(){
		if(nT.text!="" && nT.text!= "0" && nT.text!="-" && nT.text!="-0" && nT.text!=".")
			return true;
		return false;
	}
	public void setN(double x){
		nT.text=x.ToString("N3");
	}
}
