using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class OrbitScript : MonoBehaviour
{	
	public Library lib;

    private static float pi = Mathf.PI, mu = 398600.5f;
    private Vector3[] positions;
    private LineRenderer lr;
    private float baseOrthoSize, orthoSize, rNum, iNum, pNum, aNum, eNum;
	
	private static float iR, oR, wR, nuR, radius, x, y, z, xPart, yPart, zPart, xPart2, yPart2, zPart2, p, h;
	private static Vector3 rVector;

    public static Vector3 k = new Vector3(0, 1, 0);
    void Start(){
		baseOrthoSize = Camera.main.orthographicSize;
	}
    void Update(){
        lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(361);

        rNum = 90.0f;
        iNum = 45.0f;
        pNum = 90.0f;
        aNum = 10000.0f;
        eNum = 0.01f;

        // Error Checking
		rNum = lib.getR();
        iNum = lib.getI();
		pNum = lib.getP();
        aNum = lib.getA()*290.0f;//mult by 290 because getA() returns /290
        eNum = lib.getE();
        positions = CreateEllipse(aNum, eNum, iNum, rNum, pNum);

        //Draw ellipse
        for (int i = 0; i <= 360; i++) lr.SetPosition(i, positions[i]);

        //set width based on camera size
        orthoSize = Camera.main.orthographicSize;

        if ((orthoSize - baseOrthoSize) < 0) lr.SetWidth(3, 3);
        else lr.SetWidth(3 + (orthoSize - baseOrthoSize) * 0.01f, 3 + (orthoSize - baseOrthoSize) * 0.01f);
    }
    // Creates array of 3D positions to draw ellipse
    public Vector3[] CreateEllipse(float a, float e, float i, float bigO, float littleO){
        positions = new Vector3[361];
        for (int nu = 0; nu <= 360; nu++) positions[nu] = CalculateState(a, e, i, bigO, littleO, nu);
        return positions;
    }
    // Calculates the position of a satellite depending on orbital elements
    public static Vector3 CalculateState(float a, float e, float i, float bigO, float littleO, float nu){
        //convert to radians
        iR = (pi / 180) * i;
        oR = (pi / 180) * bigO;
        wR = (pi / 180) * littleO;
        nuR = (pi / 180) * nu;

        //compute radius magnitude
        radius = (a / 29.0f * (1 - Mathf.Pow(e, 2))) / (1 + (e * Mathf.Cos(nuR)));

        //compute position components
        x = radius * (Mathf.Cos(oR) * Mathf.Cos(wR + nuR) - Mathf.Sin(oR) * Mathf.Sin(wR + nuR) * Mathf.Cos(iR));
        y = radius * (Mathf.Sin(oR) * Mathf.Cos(wR + nuR) + Mathf.Cos(oR) * Mathf.Sin(wR + nuR) * Mathf.Cos(iR));
        z = radius * (Mathf.Sin(iR) * Mathf.Sin(wR + nuR));

        return new Vector3(y, z, -x);
    }
    public static Vector3 CalculateV(float a, float e, float i, float bigO, float littleO, float nu){
        //convert to radians
        iR = (pi / 180) * i;
        oR = (pi / 180) * bigO;
        wR = (pi / 180) * littleO;
        nuR = (pi / 180) * nu;

        //compute radius magnitude
        radius = (a / 29.0f * (1 - Mathf.Pow(e, 2))) / (1 + (e * Mathf.Cos(nuR)));

        //compute p
        p = a * (1 - Mathf.Pow(e, 2));

        //compute specific angular momentum
        h = Mathf.Sqrt((mu * a / 29.0f) * (1 - e * e));

        //calculate radius state vector
        rVector = CalculateState(a, e, i, bigO, littleO, nu);

        //compute part of velocity components for simpler math later
        xPart = ((rVector.y * h * e) / (radius * p)) * Mathf.Sin(nuR);
        yPart = ((rVector.z * h * e) / (radius * p)) * Mathf.Sin(nuR);
        zPart = ((-rVector.x * h * e) / (radius * p)) * Mathf.Sin(nuR);

        //other side of equation
        xPart2 = (h / radius) * (Mathf.Cos(oR) * Mathf.Sin(wR + nuR) + Mathf.Sin(oR) * Mathf.Cos(wR + nuR) * Mathf.Cos(iR));
        yPart2 = (h / radius) * (Mathf.Sin(oR) * Mathf.Sin(wR + nuR) - Mathf.Cos(oR) * Mathf.Cos(wR + nuR) * Mathf.Cos(iR));
        zPart2 = (h / radius) * Mathf.Sin(iR) * Mathf.Cos(wR + nuR);

        //compute velocity components
        x = xPart - xPart2;
        y = yPart - yPart2;
        z = zPart + zPart2;

        return new Vector3(y, z, -x);
    }
    public static Vector3 CalculateH(Vector3 r, Vector3 v){
        return Vector3.Cross(r, v);
    }
    public static Vector3 CalculateN(Vector3 h){
        if (h.magnitude <= 0f) return Vector3.zero; 
        return Vector3.Cross(OrbitScript.k, h);
    }
}