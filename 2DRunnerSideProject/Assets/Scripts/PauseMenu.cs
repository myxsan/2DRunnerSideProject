using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;

    private void OnEnable() {
        Time.timeScale = 0;
    }
    private void OnDisable() {
        Time.timeScale = 1;
    }
    
    public void Continue()
    {
        GameManager.instance.PauseMenu.SetActive(false);
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
