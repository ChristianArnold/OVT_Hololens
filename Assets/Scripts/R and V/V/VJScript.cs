using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VJScript : MonoBehaviour{
    public InputField jVelF;
    private Vector3 vector;
	public Library lib;
    void Update(){
        vector = OrbitScript.CalculateV(lib.getA()*290f, lib.getE(), lib.getI(), lib.getR(), lib.getP(), lib.getN());
        jVelF.text = (vector.x / 5).ToString();
    }
}