using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text scoreText;
    
    private static Timer instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = this.GetComponent<Text>();
        }
    }

    private void Update()
    {
        float time = Time.realtimeSinceStartup; 
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string timeText = $"{timeSpan.Minutes:D2} : {timeSpan.Seconds:D2}";
        scoreText.text = timeText;
    }
}
