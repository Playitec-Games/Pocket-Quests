using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public virtual void Open(){
        if (gameObject != null) {
            gameObject.SetActive(true);
        }
    }
    public virtual void Close(){
        if (gameObject != null) {
            gameObject.SetActive(false);
        }
    }
}
