using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour
{
    private int mouseClicks = 0;
    public Animator anim;

    public void Update()
    {
        if (mouseClicks == 1)
        {
            anim.Play("boxAnimation");
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            anim.Play("closePanel");
        }
    }
    public void addClicks()
    {
        mouseClicks = mouseClicks + 1;
    }
}
