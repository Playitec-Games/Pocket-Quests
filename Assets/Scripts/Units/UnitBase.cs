using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class UnitBase : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxHP = 5.0f;
    public AudioClip damageSound;

    protected Rigidbody2D rigidBody;
    protected Vector2 movement;
    protected Vector2 facing;
    protected float currentHP;
    protected AudioSource audioSource;

    virtual protected void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
        facing = new Vector2(0, -1.0f);
        currentHP = maxHP;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    virtual protected void FixedUpdate() {
        if (currentHP <= 0) {
            currentHP = 0;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, Collision2D collision){
        currentHP -= damage;
        // TODO: knockback
        // Debug.Log(collision.GetContact(0).point.ToString());
        // Debug.Log(transform.position.ToString());
        audioSource.PlayOneShot(damageSound);
    }

    public float GetCurrentHP() {
        return currentHP;
    }
}
