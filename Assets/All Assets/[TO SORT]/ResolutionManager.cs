using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;  // Use TMP_Dropdown instead of Dropdown

    private Resolution[] availableResolutions;

    void Start()
    {
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

        // Check if the current screen resolution is 1920x1080
        bool is1920x1080 = Screen.width == 1920 && Screen.height == 1080;

        if (!is1920x1080)
        {
            // If the current resolution isn't 1920x1080, set it as the default
            Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
        }

        // Set the dropdown value to 1920x1080 if it's not already the current resolution
        int defaultResolutionIndex = GetDefaultResolutionIndex();
        resolutionDropdown.value = defaultResolutionIndex;

        // Add listener for when the user changes the selected resolution
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    void OnResolutionChanged(int index)
    {
        // Get the selected resolution from the list
        var selectedResolution = availableResolutions[index];

        // Apply the selected resolution
        SetResolution(selectedResolution.width, selectedResolution.height);
    }

    void SetResolution(int width, int height)
    {
        // Set the selected resolution
        Screen.SetResolution(width, height, Screen.fullScreenMode);
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

    public void SetFullScreen(bool FullScreen)
    {

        Screen.fullScreen = FullScreen;

    }
}


