using UnityEngine;
using System.Collections;

public class Startup_WindowSizing : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 500);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 500);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
    }
}
