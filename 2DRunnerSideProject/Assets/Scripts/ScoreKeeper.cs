using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private float score;
    [SerializeField] float scoreMultiplier = 5;
    [SerializeField] Text scoreText;

    public float Score{ get {return score;} }

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if(!GameManager.instance.isDead)
        {
            IncreaseScorePerTime();
        }else
        {
            scoreText.enabled = false;
            this.enabled = false;
        }
    }

    private void IncreaseScorePerTime()
    {
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = score.ToString("00");
    }
}
