using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class textBoxNu : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public double value = 45.0;
    public InputField textBox;
    public bool editing = false;

    private string newText;
    private double newValue;
    public SatelliteOrbit scriptSO;
    public EarthRotation scriptER;
    public clockScript scriptCS;

    public ResetButton reset;
    public PauseButton pause;
    public Library lib;
    void Start()
    {
        lib.setN(value);
        textBox.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        newText = textBox.text;
        newValue = 45.0;

        try { newValue = Convert.ToDouble(newText); }
#pragma warning disable 0168
        catch (Exception e) { }
#pragma warning restore 0168
        if (newValue < 0.00)
        {
            newValue = 0;
        }
        else if (newValue > 360.00)
        {
            newValue = 360;
        }
        lib.setN(newValue);

    }
    public void OnSelect(BaseEventData eventData)
    {
        scriptSO.enabled = false;
        scriptER.enabled = false;
        scriptCS.enabled = false;
        editing = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (editing && !scriptSO.enabled && !scriptER.enabled)
        {
            if (lib.checkN() && (Mathf.Abs(lib.getN() * lib.PI) / 180.0f) <= 360.0)
            {
                scriptSO.ma = (Mathf.Abs(lib.getN() * lib.PI) / 180.0f);
            }
            else
            {
                scriptSO.ma = 0;
            }
            editing = false;
        }
    }
}
