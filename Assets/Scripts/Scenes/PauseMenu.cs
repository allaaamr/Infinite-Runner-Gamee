using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseScene;
    //public AudioSource pause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        PauseScene.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        PauseScene.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //pause.Play();
    }
    public void MainMenu()
    {
        
        SceneManager.LoadScene("MenuScene");
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
