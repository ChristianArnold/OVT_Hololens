using UnityEngine;
using System.Collections;

/// R Vector Script
/// Author: Thomas Fitzgerald
/// Draws a line from the origin to the satellite's current position

public class RvectorScript : MonoBehaviour{
    private Vector3 origin, satPos;
    private LineRenderer line;
    public Transform target;
    private float baseOrthoSize, orthoSize;

    void Start()
    {
        origin = new Vector3(0, 0, 0);
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, origin);
        line.SetWidth(3, 3);
        line.SetVertexCount(2);

        baseOrthoSize = Camera.main.orthographicSize;
    }
    void OnEnable()
    {
        satPos.x = target.position.x;
        satPos.y = target.position.y;
        satPos.z = target.position.z;

        line = GetComponent<LineRenderer>();
        line.SetPosition(1, satPos);
    }
    void Update()
    {
        satPos.x = target.position.x;
        satPos.y = target.position.y;
        satPos.z = target.position.z;

        line.SetPosition(1, satPos);

        //set width based on camera size
        orthoSize = Camera.main.orthographicSize;

        if ((orthoSize - baseOrthoSize) < 0)
            line.SetWidth(3, 3);
        else
            line.SetWidth(3 + (orthoSize - baseOrthoSize) * 0.01f, 3 + (orthoSize - baseOrthoSize) * 0.01f);
    }
}
