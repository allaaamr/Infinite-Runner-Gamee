using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudio;

    public void Start()
    {
    }
    public void Update()
    {
        Debug.Log(PauseMenu.GameIsPaused);
        if (PauseMenu.GameIsPaused)
        {
            backgroundAudio.Play();
            Debug.Log("Here1");
        }
        else
        {
             backgroundAudio.Pause();
        }
        
    }
}
