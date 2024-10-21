using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayCutscene : MonoBehaviour
{

    public PlayableDirector playableDirector;

    public void StartCutscene()
    {
        playableDirector.Play();
    }

}
