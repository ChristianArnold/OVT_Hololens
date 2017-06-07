using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VKScript : MonoBehaviour{
    public InputField kVelF;
    private Vector3 vector;
	public Library lib;
    void Update(){
        vector = OrbitScript.CalculateV(lib.getA()*290f, lib.getE(), lib.getI(), lib.getR(), lib.getP(), lib.getN());
        kVelF.text = (vector.y / 5).ToString();
    }
}
