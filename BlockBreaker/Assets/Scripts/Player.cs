using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Rigidbody2D playerRb;

    void Start () {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(horizontal * velocity, playerRb.velocity.y);
    }
}
