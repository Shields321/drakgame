using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutsceneScene : MonoBehaviour
{
    public void LoadCutscene()
    {

        AudioManagerTwo.instance.StopBGM();
        SceneManager.LoadScene("OpeningCutscene");

    }

}

