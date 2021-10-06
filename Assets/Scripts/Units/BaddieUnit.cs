using UnityEngine;

public class BaddieUnit : UnitBase
{
    private float decisionCountdown = 0;
    private Vector3 lastPosition;
    override protected void Start()
    {
        base.Start();
    }

    override protected void FixedUpdate() {
        base.FixedUpdate();
        if (decisionCountdown > 0) {
            decisionCountdown -= Time.fixedDeltaTime;
            rigidBody.velocity = movement;
        } else if(decisionCountdown < 0) {
            decisionCountdown = 0;
        } else if(decisionCountdown == 0) {
            float random = Random.Range(0f, 260f);
            movement = speed * new Vector2(Mathf.Cos(random), Mathf.Sin(random));
            decisionCountdown = 5.0f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        Collider2D other = collision.collider;
        if (other.tag == "Player") {
            UnitBase playerUnit = other.gameObject.GetComponent<UnitBase>();
            playerUnit.TakeDamage(2.0f, collision);
        }
        decisionCountdown = 0;
    }
}
