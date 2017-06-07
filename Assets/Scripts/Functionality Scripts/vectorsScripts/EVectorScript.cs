using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/// E Vector Script
/// Author: Thomas Fitzgerald
/// Draws a line from the origin to the perigee of the current orbit
/// So easy a caveman could do it
public class EVectorScript : MonoBehaviour{
	public Library lib;
    public InputField rF, pF;

    private Vector3 origin, perigee;
    private LineRenderer line;
    private float baseOrthoSize, orthoSize;
    void Start(){
        origin = new Vector3(0, 0, 0);
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, origin);
        line.SetWidth(3, 3);
        line.SetVertexCount(2);
        baseOrthoSize = Camera.main.orthographicSize;
    }
    void OnEnable(){
        if (lib.checkA() && lib.checkE() && lib.checkI() && (lib.checkR()||rF.text=="undef") && (lib.checkP()||pF.text=="undef")){
			perigee = OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), 0);
		}
        line = GetComponent<LineRenderer>();
        line.SetPosition(1, perigee);
    }
    void Update(){
        if (lib.checkA() && lib.checkE() && lib.checkI() && (lib.checkR()||rF.text=="undef") && (lib.checkP()||pF.text=="undef")){
			perigee = OrbitScript.CalculateState(lib.getA()*290f, lib.getE(), lib.getI(),lib.getR(), lib.getP(), 0);
		}
        line.SetPosition(1, perigee);
        orthoSize = Camera.main.orthographicSize;

        //set width based on camera size
        if ((orthoSize - baseOrthoSize) < 0) line.SetWidth(3, 3);
        else line.SetWidth(3 + (orthoSize - baseOrthoSize) * 0.01f, 3 + (orthoSize - baseOrthoSize) * 0.01f);
    }
}
