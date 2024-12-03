using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class AudioManagerTwo : MonoBehaviour
{
    // Audio Sources
    private AudioSource bgmSource;        // Background Music Source
    private AudioSource sfxSource;        // Sound Effects Source

    // Audio Clips
    public AudioClip mainMenuBGM;         // Main Menu Background Music
    public AudioClip buttonClickSFX;      // Button Click Sound Effect
    public AudioClip buttonHoverSFX;      // Hover Button Sound Effect
    public AudioClip gameStartSFX;        // Hover Button Sound Effect

    public AudioClip openingCutsceneBGM;  // Opening Cutscene Background Music

    public AudioClip gameplayBGM;         // Gameplay Background Music
    public AudioClip pausedSFX;            //Paused Sound Effect
    public AudioClip gameOverSFX;        // Hover Button Sound Effect
    public AudioClip floorClearedSFX;        // Hover Button Sound Effect



    // UI Sliders for Volume Control
    public Slider bgmSlider;              // Slider for BGM Volume
    public Slider sfxSlider;              // Slider for SFX Volume


    // Singleton Instance
    public static AudioManagerTwo instance;

    private void Awake()
    {
        // Ensure there's only one instance of AudioManagerTwo
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object between scenes
            Debug.Log("AudioManagerTwo instance set and persisting across scenes.");
        }
        else
        {
            Destroy(gameObject);  // Destroy if another instance exists
            Debug.Log("Duplicate AudioManagerTwo destroyed.");
        }

        // Set up the Audio Sources
        bgmSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true; // BGM should loop
        sfxSource.loop = false; // SFX should not loop

        bgmSource.volume = 0.8f;  // Default BGM volume
        sfxSource.volume = 0.8f;  // Default SFX volume
    }

    private void Start()
    {

        // Set initial slider values
        if (bgmSlider != null) bgmSlider.value = bgmSource.volume;
        if (sfxSlider != null) sfxSlider.value = sfxSource.volume;

        // Add listeners to sliders to adjust volume in real-time
        if (bgmSlider != null) bgmSlider.onValueChanged.AddListener(UpdateBGMVolume);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

        // Start with the Main Menu music by default
        PlayMainMenuBGM();
    }

    // Method to update BGM volume based on slider
    public void UpdateBGMVolume(float volume)
    {
        bgmSource.volume = volume;

    }

    // Method to update SFX volume based on slider
    public void UpdateSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    // Methods to play different BGM
    public void PlayMainMenuBGM()
    {
        PlayBGM(mainMenuBGM);
    }

    public void PlayOpeningCutsceneBGM()
    {
        PlayBGM(openingCutsceneBGM);
    }

    public void PlayGameplayBGM()
    {
        PlayBGM(gameplayBGM);
    }

    // Play BGM function
    public void PlayBGM(AudioClip clip)
    {
        if (clip != null && bgmSource.clip != clip)
        {
            bgmSource.Stop();           // Stop the current track
            bgmSource.clip = clip;      // Assign new clip
            bgmSource.Play();           // Play new track
        }
    }

    // Methods to play SFX
    public void PlayButtonClickSFX()
    {
        PlaySFX(buttonClickSFX);
    }

    public void PlayHoverSFX()
    {
        if (buttonHoverSFX != null)
        {
            sfxSource.PlayOneShot(buttonHoverSFX);  // Play the hover sound effect
        }
    }

    public void PlayGameStartSFX()
    {
        if (buttonHoverSFX != null)
        {
            sfxSource.PlayOneShot(gameStartSFX);  // Play the hover sound effect
        }
    }

    // Methods for Victory and Defeat SFX (Game Over and Floor Cleared)
    public void PlayGameOverSFX()
    {
        PlaySFX(gameOverSFX);
    }

    public void PlayFloorClearedSFX()
    {
        PlaySFX(floorClearedSFX);
    }

    public void PlayPausedSFX()
    {
        PlaySFX(pausedSFX);
    }


    // Play SFX function
    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip); // Play the SFX once
        }
    }

    // Optionally, you can add methods to stop or pause music or SFX
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    public void UnPauseBGM()
    {
        bgmSource.UnPause();
    }
}

