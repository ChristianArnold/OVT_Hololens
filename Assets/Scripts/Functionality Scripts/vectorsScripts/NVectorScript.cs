using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/// N Vector Script
/// Author: Thomas Fitzgerald
/// Draws a line from the origin ascending node of the current orbit
/// So easy a caveman could do it
public class NVectorScript : MonoBehaviour
{
	public Library lib;
    public InputField rF, pF;

    private Vector3 origin, r, v, h, n;
    private float magFactor, baseOrthoSize, orthoSize;
	float iTemp, rTemp, pTemp;
    private LineRenderer line;
    void Start(){
        origin = new Vector3(0, 0, 0);
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, origin);
        line.SetWidth(3, 3);
        line.SetVertexCount(2);
        baseOrthoSize = Camera.main.orthographicSize;
    }
    void OnEnable(){
        if (lib.checkA() && lib.checkE() && lib.checkI() && lib.checkN() && (lib.checkR() || rF.text =="undef") && (lib.checkP() || pF.text =="undef")){ 
			//calculate n here
			if(lib.getI()>=180) n=Vector3.zero;
			else{
				r = OrbitScript.CalculateState(lib.getA()*290.0f, lib.getE(), (lib.getI()==90f?lib.getI():lib.getI()%90f), lib.getR(), lib.getP(), lib.getP());
				v = OrbitScript.CalculateV(lib.getA()*290.0f, lib.getE(), (lib.getI()==90f?lib.getI():lib.getI()%90f), lib.getR(), lib.getP(), lib.getP());
            }
			h = OrbitScript.CalculateH(r, v);
			n = OrbitScript.CalculateN(h);
			magFactor = r.magnitude / n.magnitude;//determine size of n to fit orbit
			n *= magFactor;
		}
        line = GetComponent<LineRenderer>();
        line.SetPosition(1, n);
    }

    void Update(){
        if (lib.checkA() && lib.checkE() && lib.checkI() && lib.checkN() && (lib.checkR() || rF.text =="undef") && (lib.checkP() || pF.text =="undef")){
			//calculate n here
			if(lib.getI()>=180) n=Vector3.zero;
			else{
				r = OrbitScript.CalculateState(lib.getA()*290.0f, lib.getE(), (lib.getI()==90f?lib.getI():lib.getI()%90f), lib.getR(), lib.getP(), lib.getP());
				v = OrbitScript.CalculateV(lib.getA()*290.0f, lib.getE(), (lib.getI()==90f?lib.getI():lib.getI()%90f), lib.getR(), lib.getP(), lib.getP());
			}
			h = OrbitScript.CalculateH(r, v);
			n = OrbitScript.CalculateN(h);
			magFactor = r.magnitude / n.magnitude; //determine size of n to fit orbit
			n *= magFactor;
        }
        line.SetPosition(1, n);
        orthoSize = Camera.main.orthographicSize;//set width based on camera size
        if ((orthoSize - baseOrthoSize) < 0) line.SetWidth(3, 3);
        else line.SetWidth(3 + (orthoSize - baseOrthoSize) * 0.01f, 3 + (orthoSize - baseOrthoSize) * 0.01f);
    }
}

