using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
