using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private GameManager gameManager;
    private SettingsManager settingsManager;

    public void Awake() {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        settingsManager = (SettingsManager)FindObjectOfType(typeof(SettingsManager));
    }

    public void PlayGame(){
        gameManager.InitGame();
    }
    public void OpenSettings(){
        settingsManager.Open();
    }
    public void QuitGame(){
        gameManager.QuitGame();
    }
    public void Continue(){
        gameManager.ReInitPlayer();
    }
}
