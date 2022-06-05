using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore = 0;
    private Text scoreText;

    private static Score instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = this.GetComponent<Text>();
        }
    }

    public static Score Get()
    {
        return instance;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void IncreaseScore(int val)
    {
        currentScore += val;
        scoreText.text = "= " + currentScore;
    }
}
