using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerWeapon : MonoBehaviour
{
    private AudioSource audioSource;

    void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        Collider2D other = collision.collider;
        if (other.tag == "Baddie") {
            UnitBase baddieUnit = other.gameObject.GetComponent<UnitBase>();
            baddieUnit.TakeDamage(2.0f, collision);
        }
    }
}
