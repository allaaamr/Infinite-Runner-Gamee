using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
    public TMP_Text DisplayedScore;
    public GameObject GameOverScene;
    public AudioSource gameOver_audio;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        DisplayedScore.text = "Score: " + score;
        gameOver_audio.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        GameOverScene.SetActive(false);
    }
}
