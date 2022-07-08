using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    [SerializeField] int scoreMultiplier = 5;
    [SerializeField] Text scoreText;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        IncreaseScorePerTime();
    }

    private void IncreaseScorePerTime()
    {
        score = Mathf.CeilToInt(Time.time * scoreMultiplier);
        scoreText.text = score.ToString("00");
        Debug.Log(score);
    }
}
