using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] Text gameOverScoreText;
    [SerializeField] SceneFader sceneFader;
    
    private void Start() {
        this.gameObject.SetActive(false);
    }

    private void OnEnable() {
        SetGameOverScore();
    }

    private void SetGameOverScore()
    {
        gameOverScoreText.text = $"FINAL SCORE : {Mathf.FloorToInt(scoreKeeper.Score)}";
    }

    public void Retry()
    {
        sceneFader.FadeTo("MainGame");
    }

    public void Menu()
    {
        sceneFader.FadeTo("Menu");
    }
}
