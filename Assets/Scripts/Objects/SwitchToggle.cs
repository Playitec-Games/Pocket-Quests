using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    public GameObject[] toggledObjects;
    private string colliderTag = null;
    void OnTriggerEnter2D(Collider2D other){
        // if (other.tag == "Player" 
        //     || other.tag == "Baddie"
        //     || other.tag == "Pushable"
        // ) {
        if(colliderTag == null) {
            colliderTag = other.tag;
            if (toggledObjects != null) {
                foreach (var toggledObject in toggledObjects) {
                    toggledObject.SetActive(false);
                }
            }
        }
        // }
    }

    void OnTriggerExit2D(Collider2D other){ 
        if (colliderTag != null && other.tag == colliderTag) {
            if (toggledObjects != null) {
                foreach (var toggledObject in toggledObjects) {
                    toggledObject.SetActive(true);
                }
            }
            colliderTag = null;
        }
    }
}
