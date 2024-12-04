using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;  // Your TMP_Dropdown for resolution
    public TMP_Dropdown fullscreenDropdown;  // Your TMP_Dropdown for fullscreen mode
    public Slider volumeSlider;    // Reference to Unity's Slider for audio volume
    private Resolution[] availableResolutions;

    void Start()
    {
        // Load saved settings
        LoadSettings();

        // Get all available resolutions from Unity
        availableResolutions = Screen.resolutions;

        // Create a list to store resolution options as strings
        var resolutionOptions = new System.Collections.Generic.List<string>();

        // Populate the resolutionOptions list with the available resolutions
        foreach (var resolution in availableResolutions)
        {
            resolutionOptions.Add(resolution.width + "x" + resolution.height);
        }

        // Set the dropdown options with the list of resolutions
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionOptions);

        // Set the default value in the dropdown to the saved resolution
        resolutionDropdown.value = GetDefaultResolutionIndex();

        // Add listener for when the user changes the selected resolution
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);

        // Add listener for fullscreen toggle
        fullscreenDropdown.onValueChanged.AddListener(OnFullscreenChanged);

        // Add listener for volume slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnResolutionChanged(int index)
    {
        var selectedResolution = availableResolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreenMode);

        // Save selected resolution
        PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.height);
        PlayerPrefs.Save(); // Save to disk immediately
        Debug.Log("Resolution Saved: " + selectedResolution.width + "x" + selectedResolution.height); // Debug log
    }

    void OnFullscreenChanged(int index)
    {
        bool isFullscreen = index == 1; // Assuming index 1 means fullscreen and index 0 means windowed
        Screen.fullScreen = isFullscreen;

        // Save fullscreen setting
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save(); // Save to disk immediately
        Debug.Log("Fullscreen Saved: " + (isFullscreen ? "True" : "False")); // Debug log
    }

    void OnVolumeChanged(float volume)
    {
        // Assuming you have an AudioSource component to control the volume
        AudioListener.volume = volume;

        // Save volume setting
        PlayerPrefs.SetFloat("AudioVolume", volume);
        PlayerPrefs.Save(); // Save to disk immediately
        Debug.Log("Audio Volume Saved: " + volume); // Debug log
    }

    void LoadSettings()
    {
        // Load resolution
        int width = PlayerPrefs.GetInt("ResolutionWidth", 1920);  // Default to 1920 if not found
        int height = PlayerPrefs.GetInt("ResolutionHeight", 1080); // Default to 1080 if not found
        Screen.SetResolution(width, height, Screen.fullScreenMode);

        // Load fullscreen mode
        int fullscreen = PlayerPrefs.GetInt("Fullscreen", 1);  // Default to fullscreen if not found
        Screen.fullScreen = (fullscreen == 1);

        // Load audio volume
        float volume = PlayerPrefs.GetFloat("AudioVolume", 1f);  // Default to 1 if not found
        AudioListener.volume = volume;

        // Set the dropdown values based on saved settings
        SetResolutionDropdownValue(width, height);
        SetFullscreenDropdownValue(fullscreen);
        volumeSlider.value = volume;

        // Debug log for loaded settings
        Debug.Log("Loaded Settings: Resolution " + width + "x" + height + ", Fullscreen: " + (fullscreen == 1 ? "True" : "False") + ", Volume: " + volume);
    }

    void SetResolutionDropdownValue(int width, int height)
    {
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            if (availableResolutions[i].width == width && availableResolutions[i].height == height)
            {
                resolutionDropdown.value = i;
                break;
            }
        }
    }

    void SetFullscreenDropdownValue(int fullscreen)
    {
        fullscreenDropdown.value = fullscreen == 1 ? 1 : 0;
    }

    int GetDefaultResolutionIndex()
    {
        // Find the index of the current screen resolution
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            if (availableResolutions[i].width == Screen.width && availableResolutions[i].height == Screen.height)
            {
                return i; // Return the index that matches the current resolution
            }
        }
        return 0; // Default to the first resolution if not found
    }
}
