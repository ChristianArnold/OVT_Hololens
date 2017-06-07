using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour
{
    public GameObject earth;
    public float speed;
	public clockScript clock;
    void Update()
    {
        earth.transform.Rotate(0, speed * (clock.multiplier), 0);
    }
}
