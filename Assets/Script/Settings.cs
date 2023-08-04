using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public SaveData saveData;
    public Toggle sunToggle;
    public Toggle fullscreenToggle;
    public Slider sensitivitySlider;

    private void Start()
    {
        // Load the saved data when the game starts.
        LoadSettings();
    }

    private void LoadSettings()
    {
        // Load the SaveData from the SaveData ScriptableObject
        sunToggle.isOn = saveData.isSunActive;
        sensitivitySlider.value = saveData.playerSensitivity;

        // Load fullscreen setting from PlayerPrefs or any other save method you prefer.
        bool isFullscreen = PlayerPrefs.GetInt("IsFullscreen", 1) == 1;
        fullscreenToggle.isOn = isFullscreen;
    }


    public void OnSensitivityChanged(float newSensitivity)
    {
        saveData.playerSensitivity = newSensitivity;
    }

    public void OnSunToggleChanged(bool isSunActive)
    {
        saveData.isSunActive = isSunActive;
    }

    public void OnFullscreenToggle(bool isFullscreen)
    {
        // Save the fullscreen setting to PlayerPrefs or any other save method you prefer.
        PlayerPrefs.SetInt("IsFullscreen", isFullscreen ? 1 : 0);
        Screen.fullScreen = isFullscreen;
    }

    public void SaveSettings()
    {
        // Save the SaveData to PlayerPrefs or any other save method you prefer.
        PlayerPrefs.SetInt("IsSunActive", saveData.isSunActive ? 1 : 0);
        PlayerPrefs.SetFloat("PlayerSensitivity", saveData.playerSensitivity);
        PlayerPrefs.SetInt("IsFullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadScene(string sceneName)
    {
        // Save the SaveData before switching to a new scene.
        SaveSettings();

        // Load the new scene.
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
