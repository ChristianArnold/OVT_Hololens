using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// V Vector Script
/// Author: Thomas Fitzgerald
/// Draws a line to represent satellite's current velocity vector

public class VvectorScript : MonoBehaviour{
    public Library lib;
	public InputField rF, pF;

    private Vector3 satPos, velocity, vvect;
    private LineRenderer line;
    public Transform target;
    private float baseOrthoSize, orthoSize;
    void Start(){
        line.SetVertexCount(2);
        baseOrthoSize = Camera.main.orthographicSize;
    }

    void OnEnable(){
        satPos.x = target.position.x;
        satPos.y = target.position.y;
        satPos.z = target.position.z;

        line = GetComponent<LineRenderer>();
        {
            if (lib.checkA() && lib.checkE() && lib.checkI() &&(lib.checkR() || rF.text =="undef") && (lib.checkP() || pF.text =="undef")){
				vvect = satPos + 5 * OrbitScript.CalculateV(lib.getA()*290.0f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), lib.getN());
            }
            line.SetPosition(1, vvect);
        }
        line.SetPosition(0, satPos);
    }

    void Update(){
        satPos.x = target.position.x;
        satPos.y = target.position.y;
        satPos.z = target.position.z;
        {
           if (lib.checkA() && lib.checkE() && lib.checkI() &&(lib.checkR() || rF.text =="undef") && (lib.checkP() || pF.text =="undef")){
				vvect = satPos + 5 * OrbitScript.CalculateV(lib.getA()*290.0f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), lib.getN());
            }
            line.SetPosition(1, vvect);
        }
        line.SetPosition(0, satPos);
        orthoSize = Camera.main.orthographicSize;

        //set width based on camera size
        if ((orthoSize - baseOrthoSize) < 0) line.SetWidth(3, 3);
        else line.SetWidth(3 + (orthoSize - baseOrthoSize) * 0.01f, 3 + (orthoSize - baseOrthoSize) * 0.01f);
    }
}
