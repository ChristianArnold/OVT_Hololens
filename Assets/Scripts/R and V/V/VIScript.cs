using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VIScript : MonoBehaviour{
    public InputField iVelF;
    private Vector3 vector;
	public Library lib;
    void Update(){
        vector = OrbitScript.CalculateV(lib.getA()*290f, lib.getE(), lib.getI(), lib.getR(), lib.getP(), lib.getN());
        iVelF.text = (-vector.z / 5).ToString();
    }
}
