using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject PauseMenu;
    [SerializeField] Button audioButton;
    public bool isDead {get; set;} = false;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start() {
        PauseMenu.SetActive(false);
        SceneFader.instance.StartFade();
    }

    private void OnEnable() {
        MusicPlayer.instance.audioButton = this.audioButton;
    }
    private void OnDisable() {
        MusicPlayer.instance.audioButton = null;
    }

    public void PauseButton()
    {
        PauseMenu.SetActive(true);
    }

    public void AudioButton()
    {
        MusicPlayer.instance.ToggleMusic();
    }
}
