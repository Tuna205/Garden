using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    private int currentHp = 3;
    public List<Image> hearths;
    public Sprite emptyHeart;

    private static HealthCounter instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static HealthCounter Get()
    {
        return instance;
    }

    public void DecreaseHp(int val)
    {
        currentHp -= val;

        for (int i = 0; i < hearths.Count; i++)
        {
            if (currentHp <= i)
            {
                hearths[i].sprite = emptyHeart;
            }
        }

        if (currentHp == 0)
        {
            int currentScore = Score.Get().GetScore();
            int savedScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
            if (currentScore > savedScore)
            {
                PlayerPrefs.SetInt("HighScore", Score.Get().GetScore());
            }
#if UNITY_EDITOR
            // UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
