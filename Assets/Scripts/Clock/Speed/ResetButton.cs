using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetButton : MonoBehaviour {
	int zero;
	public textBoxNu nuScript;
	public clockScript clockScript;
	public PauseButton pause;
	public SatelliteOrbit scriptSO;
	public EarthRotation scriptER;
	public Transform EarthImage;
	public Library lib;
	
	public void onButtonClick(){
	zero = 0;
	nuScript.textBox.text = zero.ToString("N1"); 

	scriptSO.enabled = false;
	scriptER.enabled = false;
	nuScript.editing = true;
	nuScript.OnDeselect(null);

	EarthImage.rotation = Quaternion.identity;

	pause.clicks = 0;
	pause.pauseText.text = lib.pause;
	clockScript.totalseconds = 0;
	}
}
