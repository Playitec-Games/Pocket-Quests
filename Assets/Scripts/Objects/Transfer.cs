using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour
{
    public string targetScene = "YouWin";
    public float targetX;
    public float targetY;
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            GameManager gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
            gameManager.LoadLevel(targetScene, targetX, targetY);
        }
    }
}
