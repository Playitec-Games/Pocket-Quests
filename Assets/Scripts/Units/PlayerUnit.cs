using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerUnit : UnitBase
{
    public GameObject itemA = null;
    public GameObject itemB = null;    private float itemACountdown;
    private float itemBCountdown;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    override protected void Start() {
        base.Start();
        itemACountdown = 0;
        itemBCountdown = 0;
    }

    override protected void FixedUpdate() {
        if (currentHP < 0) {
            SceneManager.LoadScene("GameOver");
        }

        base.FixedUpdate();
        
        if (itemACountdown > 0) {
            itemACountdown -= Time.fixedDeltaTime;
        } else if(itemACountdown < 0) {
            itemA.SetActive(false);
            itemACountdown = 0;
        } else if(itemACountdown == 0 && itemBCountdown == 0) {
            rigidBody.velocity = movement; //* Time.fixedDeltaTime
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (itemA != null && itemACountdown <= 0) {
            itemA.transform.SetPositionAndRotation(
                transform.position 
                + new Vector3(facing.x,facing.y,0),
                transform.rotation
            );
            rigidBody.velocity = Vector2.zero;
            itemACountdown = 1.0f / speed;
            itemA.SetActive(true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        movement = (speed * moveInput);
        if (moveInput != Vector2.zero) {
            facing = moveInput;
        }
    }
}
