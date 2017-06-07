using UnityEngine;
using System.Collections;

public class LoadScript : MonoBehaviour
{
    public int mouseClicks = 0;
    public Animator loadAnim;

    public void Update()
    {
        if (mouseClicks == 1)
        {
            loadAnim.Play("loadMenuOpen");
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            loadAnim.Play("loadMenuClose");
        }
    }
    public void addClicks()
    {
        mouseClicks += 1;
    }
}
