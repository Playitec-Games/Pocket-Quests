using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public Text textBox;
    // Start is called before the first frame update
    public void updateText(string incText) {
        textBox.text = incText;
    }
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
