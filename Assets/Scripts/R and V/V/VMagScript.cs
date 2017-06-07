using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VMagScript : MonoBehaviour
{

    public Text vF;

    private float vMag;
    private Vector3 vector;
	public Library lib;
    void Update()
    {
        vector = OrbitScript.CalculateV(lib.getA()*290f, lib.getE(), lib.getI(),
                                      lib.getR(), lib.getP(), lib.getN());

        vMag = vector.magnitude / 5;
        vF.text = vMag.ToString();
    }
}

