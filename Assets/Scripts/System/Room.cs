using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> baddies;
    public List<GameObject> baddieClearObjects;
    private bool runLogic = false;

    void FixedUpdate(){
        if (runLogic) {
        // public GameObject[] newBaddies = null;
        List<GameObject> filteredBaddies = new List<GameObject>();
        foreach (var baddie in baddies) {
            if (baddie != null) {
                filteredBaddies.Add(baddie);
            }
        }
        baddies = filteredBaddies;
        if (
            (baddies == null || baddies.ToArray().Length < 1) 
            && baddieClearObjects != null
        ) {
            foreach (var clearObject in baddieClearObjects) {
                Destroy(clearObject);
            }
            baddieClearObjects = null;
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            Camera.main.transform.SetPositionAndRotation(
                new Vector3(transform.position.x, transform.position.y, -16),
                Camera.main.transform.rotation
            );
            if (baddies != null) {
                foreach (var baddie in baddies) {
                    if (baddie != null) {
                        baddie.SetActive(true);
                    }
                }
            }
            runLogic = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){ 
        if (other.tag == "Player") {
            if (baddies != null) {
                foreach (var baddie in baddies) {
                    if (baddie != null) {
                    baddie.SetActive(false);
                    }
                }
            }
            runLogic = false;
        } else if(other.tag == "Baddie") {
            Destroy(other.gameObject);
        }
    }
}
