using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    public TMP_Text DisplayedScore;
    public void Setup(int score)
    {
        Debug.Log("GameOver Setup");
        gameObject.SetActive(true);
        DisplayedScore.text = "Score: " + score;
        Debug.Log("Set To True");
    }
}
