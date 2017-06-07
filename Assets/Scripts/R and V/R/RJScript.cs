using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RJScript : MonoBehaviour{
    public InputField jRadF;
    private Vector3 pos;
	public Library lib;
    void Update(){
        pos = 29 * OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), lib.getN());
        jRadF.text = (pos.x).ToString();
    }
}
