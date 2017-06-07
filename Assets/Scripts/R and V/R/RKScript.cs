using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RKScript : MonoBehaviour{
    public InputField kRadF;
    private Vector3 pos;
	
	public Library lib;
    void Update(){
        pos = 29 * OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), lib.getN());
        kRadF.text = (pos.y).ToString();
    }
}
