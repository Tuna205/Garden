using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text scoreText;
    
    private static HighScore instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = this.GetComponent<Text>();
        }
    }
    
    void Start()
    {
        int score = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        scoreText.text = "HIGH SCORE: " + score;
    }
}
