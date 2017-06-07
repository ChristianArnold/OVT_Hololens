using UnityEngine;
using System.Collections;

public class directionScript : MonoBehaviour {
    public GameObject text;
    public Transform target;

	void Update () {
        text.transform.rotation = Quaternion.LookRotation(transform.position - target.position);
	}
}
