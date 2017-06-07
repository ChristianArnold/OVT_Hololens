using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rVScript : MonoBehaviour
{
    public int mouseClicks = 0;
    public GameObject rvPackage;
    public Text rVText;
	
	public Library lib;
    void Update()
    {
        if (mouseClicks == 1)
        {
            rVText.text = lib.rvOff;
            rvPackage.SetActive(true);
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            rVText.text = lib.rvOn;
            rvPackage.SetActive(false);
        }
    }
    public void addClicks()
    {
        mouseClicks += 1;
    }
}
