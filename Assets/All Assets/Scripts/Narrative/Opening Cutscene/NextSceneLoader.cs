using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    private AudioManagerTwo audioManager;

    void OnEnable()
    {
        // Load the gameplay scene
        SceneManager.LoadScene("Gameplay");

        AudioManagerTwo.instance.PlayGameplayBGM();

    }
}

