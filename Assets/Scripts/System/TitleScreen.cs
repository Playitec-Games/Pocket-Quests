using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    private GameManager gameManager;

    public void Start() {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    public void PlayGame(){
        gameManager.InitGame();

    }
    public void OpenSettings(){
        if (settingsCanvas != null) {
            mainCanvas.SetActive(false);
            settingsCanvas.SetActive(true);
        }
    }

    public void SetVolume(System.Single incVol) {
        AudioListener.volume = incVol;
    }
    public void CloseSettings(){
        if (settingsCanvas != null) {
            settingsCanvas.SetActive(false);
            mainCanvas.SetActive(true);
        }
    }
    public void QuitGame(){
        gameManager.QuitGame();
    }
}
