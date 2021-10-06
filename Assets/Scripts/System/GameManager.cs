using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject settingsCanvas;
    public GameObject playerPrefab;
    public string initLevel = "TestLevel";
    public float initPlayerX = 0;
    public float initPlayerY = 0;
    private string targetLevel;
    private float targetPlayerX;
    private float targetPlayerY;
    private GameObject playerObject;
    private PlayerUnit playerUnit;
    private HudManager hudManager;
    private SettingsManager settingsManager;
    private float playerDepth = 0;
    private float cameraDepth = -32;    
    void Awake() {
        DontDestroyOnLoad(gameObject);
        hudManager = hudCanvas.GetComponent<HudManager>();
        settingsManager = settingsCanvas.GetComponent<SettingsManager>();
    }
    private void FixedUpdate() {
        if (playerUnit != null) {
            hudManager.updateHP(playerUnit.GetCurrentHP().ToString());
        }
    }

    public void InitGame() {
        InitPlayer(initLevel,initPlayerX,initPlayerY);
    }

    public void ReInitGame() {
        InitPlayer(targetLevel,targetPlayerX,targetPlayerY);
    }

    public void InitPlayer(string levelName, float x, float y) {
        if (playerUnit != null) {
            playerUnit = null;
        }
        if (playerObject != null) {
            Destroy(playerObject);
        }
        playerObject = GameObject.Instantiate(playerPrefab);
        playerUnit = playerObject.GetComponent<PlayerUnit>();
        LoadLevel(levelName,x,y);
        hudCanvas.SetActive(true);
    }
    public void ReInitPlayer() {
        InitPlayer(targetLevel, targetPlayerX, targetPlayerY);
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
    public void ReloadLevel() {
        LoadLevel(targetLevel, targetPlayerX, targetPlayerY);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
