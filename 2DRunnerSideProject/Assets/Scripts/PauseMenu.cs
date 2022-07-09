using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable() {
        Time.timeScale = 0;
    }
    private void OnDisable() {
        Time.timeScale = 1;
    }
    
    public void Continue()
    {
        //Time.timeScale = 1;
        GameManager.instance.PauseMenu.SetActive(false);
    }

    public void Retry()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("GO MENU");
    }

}
