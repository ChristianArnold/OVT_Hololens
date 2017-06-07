using UnityEngine;
using System.Collections;

public class disableCameraScript : MonoBehaviour
{
    public int mouseClicks = 0;
	public CameraScript cameraScript;
    void Update()
    {
        if (mouseClicks == 1)
        {
            cameraScript.enabled = false;
        }
        if (mouseClicks == 2 | mouseClicks == 0)
        {
            cameraScript.enabled = true;
            mouseClicks = 0;
        }
    }

    public void addClicks()
    {
        mouseClicks += 1;
    }
}
