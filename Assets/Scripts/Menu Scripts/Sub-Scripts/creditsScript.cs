using UnityEngine;
using System.Collections;

public class creditsScript : MonoBehaviour
{
    private int mouseClicks = 0;
    public Animator creditAnim;

    public void Update()
    {
        if (mouseClicks == 1)
        {
            creditAnim.Play("creditsOpen");
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            creditAnim.Play("creditsClose");
        }
    }
    public void addClicks()
    {
        mouseClicks = mouseClicks + 1;
    }
}
