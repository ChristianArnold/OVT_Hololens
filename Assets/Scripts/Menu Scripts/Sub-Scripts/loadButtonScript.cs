using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loadButtonScript : MonoBehaviour
{
    public Dropdown myDropDown;
    private int selected;
    public ResetButton reset;
    public Library lib;
    void Start()
    {
        myDropDown.onValueChanged.AddListener(delegate { dropDownValueChanged(myDropDown); });
        selected = 0;
    }
    void dropDownValueChanged(Dropdown dropper) { selected = dropper.value; }
    public void buttonHit()
    {
        reset.onButtonClick();
        if (selected == 0)
        {
            lib.setA(10000); lib.setE(.01);
            lib.setI(45); lib.setR(90);
            lib.setP(90);
        }
        else if (selected == 1)
        {
            lib.setA(26845.637); lib.setE(0.0008830);
            lib.setI(54.9762); lib.setR(183.1958);
            lib.setP(206.1999); lib.setN(0.0008830);
        }
        else if (selected == 2)
        {
            lib.setA(42149.137); lib.setE(0.0009);
            lib.setI(4.3); lib.setR(0);
            lib.setP(90);
        }
        else if (selected == 3)
        {
            lib.setA(23237.137); lib.setE(0.7089928);
            lib.setI(62.5783); lib.setR(278.2967);
            lib.setP(282.6677);
        }
        else if (selected == 4)
        {
            lib.setA(7342.27); lib.setE(0.012);
            lib.setI(69); lib.setR(237.61);
            lib.setP(16.16);
        }
        else if (selected == 5)
        {
            lib.setA(6863.137); lib.setE(0.0009224);
            lib.setI(35.4259); lib.setR(32.4259);
            lib.setP(249.5203);
        }
        else if (selected == 6)
        {
            lib.setA(7100); lib.setE(0);
            lib.setI(24); lib.setR(0);
            lib.setPundef();

            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "u";
        }
        else if (selected == 7)
        {
            lib.setA(6600); lib.setE(0);
            lib.setI(90); lib.setR(0);
            lib.setPundef();

            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "u";
        }
        else if (selected == 8)
        {
            lib.setA(42164.137); lib.setE(0.0000628);
            lib.setI(0.0136); lib.setRundef();
            lib.setPundef();

            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
        }
        else if (selected == 9)
        {
            lib.setA(6986.637); lib.setE(0.0007470);
            lib.setI(98.0692); lib.setR(54.6316);
            lib.setP(191.3684);
        }
        else if (selected == 10)
        {
            lib.setA(10000); lib.setE(0);
            lib.setI(0); lib.setRundef();
            lib.setPundef();

            GameObject.Find("trueAnomalyPackage").GetComponent<Text>().text = "l";
        }
        lib.setN(0);
    }
}
