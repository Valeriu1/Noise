using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score = 0;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.SetText(highScore.ToString());
        }
        
    }


    public void ZombieKilled()
    {
        score++;
        scoreText.SetText(score.ToString());
        if (score >= highScore)
        {
            highScore = score;
            highScoreText.SetText(highScore.ToString());
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
