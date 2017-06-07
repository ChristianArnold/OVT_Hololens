using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SatelliteOrbit : MonoBehaviour{
    public Transform target;

    int count, o, n;
    float[] E = new float[2];
    float heuristic = 10e-7f, a, e, X, Y, ta, b, h, x, y, deltaM, PI = Mathf.PI;
    public float nu;
    public float ma, degHr, limiter;
	public Library lib;
	public EarthRotation earth;
	Transform trans;
	public clockScript clock;
    // Use this for initialization
    void Start(){
        x = target.transform.position.x;
        y = target.transform.position.y;
		trans=this.transform;
    }
    // Update is called once per frame
    void Update(){
        updateValues();

        ma += deltaM;
        ta = mTot();
        X = x + (a * Mathf.Cos(ta) - h);
        Y = y + (b * Mathf.Sin(ta));
        nu = (ta * 180) / PI;
        lib.setN(nu);

        this.gameObject.transform.position = target.transform.position - new Vector3(Y, 0, X) * 10.0f;
		trans.RotateAround(target.position, Vector3.up, lib.getP() - 180.0f);
        trans.RotateAround(target.position, Vector3.back, lib.getI() - 180.0f);
        trans.RotateAround(target.position, Vector3.down, lib.getR() - 180.0f);
        trans.LookAt(target);
        trans.RotateAround(this.gameObject.transform.position, this.gameObject.transform.up, 90);
    }

    // Mathematical Operations
    void updateValues(){
        a=lib.getA();
        e=lib.getE();
        // speed of satellite
        b = a * Mathf.Sqrt(1 - Mathf.Pow(e, 2));
        h = a * e;
        deltaM = (Mathf.Sqrt(398600.5f / Mathf.Pow(a, 3)));                     //rads per sec

        degHr = earth.speed*-1.0f;         //get the value from the EarthRotation script, <1.0f>
        limiter = Mathf.Ceil(-86.56f * Mathf.Log(degHr) + 60.0f)*9.26f/(clock.multiplier);
        deltaM /= limiter;
    }

    // Mathematical Magic...
    float mTot(){
        while (ma >= 2 * PI) ma -= 2 * PI;

        if (ma > 5.5){
            E[0] = ma + e;
            E[1] = ma / 2;
        }
        else{
            E[0] = ma + (e / 2);
            E[1] = ma;
        }
        count = 0;
        o = ((count + 1) % 2);
        n = ((count) % 2);

        while (Mathf.Abs(E[o] - E[n]) > heuristic && count < 100){
            o = ((count + 1) % 2);
            n = ((count) % 2);
            E[n] = E[o] + ((ma - (E[o] - e * Mathf.Sin(E[o]))) / (1 - e * Mathf.Cos(E[o])));
            count++;
            if (E[n] > (ma + e)) E[n] = ma + e;
        }
        if (count > 99) Debug.Log(ma + "..." + e);
        return E[n];
    }
}
