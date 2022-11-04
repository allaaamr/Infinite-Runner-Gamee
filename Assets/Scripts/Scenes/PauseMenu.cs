using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseScene;
    public GameObject gameScene;
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
        gameScene.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        PauseScene.SetActive(true);
        gameScene.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //pause.Play();
    }
    public void MainMenu()
    {
        gameScene.SetActive(true);
        PauseScene.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }
    public void Replay()
    {
        gameScene.SetActive(true);
        PauseScene.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

}
