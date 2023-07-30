using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public SaveData saveData;
    public Toggle SunActive;
    public Slider sensitivity;

    public void Start()
    {
        SunActive.isOn = saveData.isSunActive;
        sensitivity.value = saveData.playerSensitivity;
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Sun(bool isSunActive)
    {
        saveData.isSunActive = isSunActive;
    }

    public void ChangeSensivity(float currentSensivity)
    {
        saveData.playerSensitivity = currentSensivity;
    }
}
