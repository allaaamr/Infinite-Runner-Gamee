using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
    public TMP_Text DisplayedScore;
    public GameObject GameOverScene;

    public void Setup(int score)
    {
        Debug.Log("GameOver Setup");
        gameObject.SetActive(true);
        DisplayedScore.text = "Score: " + score;
        Debug.Log("Set To True");
    }
    public void Restart()
    {

        SceneManager.LoadScene("SampleScene");
        GameOverScene.SetActive(false);
    }
}
