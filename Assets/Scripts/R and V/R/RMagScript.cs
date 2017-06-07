using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RMagScript : MonoBehaviour {

    public Text radF;

    private float rMag;
    private Vector3 pos;
	public Library lib;
	void Update (){
        pos = OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(), lib.getR(), lib.getP(), lib.getN());
        radF.text = (pos.magnitude * 29).ToString();
	}
}
