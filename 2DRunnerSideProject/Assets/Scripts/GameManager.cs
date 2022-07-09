using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject PauseMenu;



    private void Start() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        PauseMenu.SetActive(false);
    }

    public void PauseButton()
    {

        PauseMenu.SetActive(true);
    }

}
