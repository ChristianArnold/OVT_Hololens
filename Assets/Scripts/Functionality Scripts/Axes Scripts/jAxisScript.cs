using UnityEngine;
using System.Collections;

/// Axis Script
/// Author: Thomas Fitzgerald
/// Draws an axis from Earth that resizes with the camera

public class jAxisScript : MonoBehaviour
{
    private float baseOrthoSize, orthoSize;
    private Vector3 start, end;
    private LineRenderer line;

    // Use this for initialization
    void Start()
    {
        start = new Vector3(0, 0, 0);
        end = new Vector3(750, 0, 0);
        baseOrthoSize = Camera.main.orthographicSize;

        line = GetComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        line.SetColors(Color.green, Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        orthoSize = Camera.main.orthographicSize;
        end.x = 750 + (orthoSize - baseOrthoSize);

        line.SetPosition(1, end);

        //change width depending on camera size
        line.SetWidth(15 + (orthoSize - baseOrthoSize) * 0.01f, 10 + (orthoSize - baseOrthoSize) * 0.01f);
    }
}
