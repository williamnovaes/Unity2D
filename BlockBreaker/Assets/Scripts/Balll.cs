using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balll : MonoBehaviour
{
    private Rigidbody2D ballRb;
    [SerializeField] private float force;
    [SerializeField] private LayerMask whatIsGround;
    private LayerMask ground;
    void Awake() {
        ballRb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ballRb.AddForce(new Vector2(force, -force));
        ground = LayerMask.GetMask("Ground");
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject != null && other.gameObject.tag.Equals("Ground")) {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null) {
                gm.Die();
            }
        } else if (other.gameObject.tag.Equals("Brick")) {
            Brick brick = other.gameObject.GetComponent<Brick>();
            if (brick != null) {
                brick.TakeDamage();
            }
        }
    }
}
