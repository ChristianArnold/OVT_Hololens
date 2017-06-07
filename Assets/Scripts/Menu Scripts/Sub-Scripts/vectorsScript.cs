using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class vectorsScript : MonoBehaviour
{
    private int mouseClicks = 0;
    public GameObject vectors;
    public Text vectorText;
	
	public Library lib;
    void Update()
    {
        if (mouseClicks == 1)
        {
            vectorText.text = lib.vectorsOn;
            vectors.SetActive(false);
        }
        if (mouseClicks == 2)
        {
            mouseClicks = 0;

            vectorText.text = lib.vectorsOff;
            vectors.SetActive(true);
        }
    }
    public void addClicks()
    {
        mouseClicks = mouseClicks + 1;
    }
}
