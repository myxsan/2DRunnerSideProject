using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private float score;
    [SerializeField] float scoreMultiplier = 5;
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
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = score.ToString("00");
        Debug.Log(score);
    }
}
