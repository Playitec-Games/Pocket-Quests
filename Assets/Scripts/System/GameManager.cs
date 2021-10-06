using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject playerPrefab;
    public Text currentHP;
    public string initLevel = "TestLevel";
    public float initPlayerX = 0;
    public float initPlayerY = 0;
    private string targetLevel;
    private float targetPlayerX;
    private float targetPlayerY;
    private GameObject playerObject;
    private PlayerUnit playerUnit;
    private float playerDepth = 0;
    private float cameraDepth = -32;    
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate() {
        if (playerUnit != null) {
            currentHP.text = playerUnit.GetCurrentHP().ToString();
        }
    }

    public void InitGame() {
        if (playerUnit != null) {
            playerUnit = null;
        }
        if (playerObject != null) {
            Destroy(playerObject);
        }
        InitPlayer(initLevel,initPlayerX,initPlayerY);
    }

    public void InitPlayer(string levelName, float x, float y) {
        playerObject = GameObject.Instantiate(playerPrefab);
        playerUnit = playerObject.GetComponent<PlayerUnit>();
        LoadLevel(levelName,x,y);
        hudCanvas.SetActive(true);
    }

    public void ScreenTransfer(float x, float y) {    
        Camera.main.transform.SetPositionAndRotation(
            new Vector3(x, y, cameraDepth),
            Camera.main.transform.rotation
        );
    }

    public void LoadLevel(string levelName, float x, float y) {
        LoadLevel(levelName);
        if (playerObject != null) {
            targetPlayerX = x;
            targetPlayerY = y;
            playerObject.transform.SetPositionAndRotation(
                new Vector3(x,y,playerDepth),
                playerObject.transform.rotation
            );
        }
    }
    public void LoadLevel(string levelName) {
        targetLevel = levelName;
        SceneManager.LoadScene(levelName);
    }

    // public void SetVolume(float incVol) {
    //     AudioListener.volume = incVol;
    // }

    public void QuitGame(){
        Application.Quit();
    }
}
