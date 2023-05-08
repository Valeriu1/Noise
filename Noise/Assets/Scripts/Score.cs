using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("2");
        highScoreText.SetText("3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
