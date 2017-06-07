using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public int mouseClicks = 0;
    public Animator anim;
    public GameObject loaderObject;
	public Camera cam;
	public LoadScript loadScript;
	public disableCameraScript dcs;

    public void Update()
    {
        if (mouseClicks == 1)
        {
            anim.Play("menuButton");
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            anim.Play("closeMenu");
            if (loadScript.mouseClicks == 1) 
            { 
                loadScript.addClicks();
            }
            if (dcs.mouseClicks == 1)
            {
                dcs.addClicks();
            }
        }
    }
    public void addClicks()
    {
        mouseClicks +=1;
    }
}
