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
        ballRb.AddForce(new Vector2(force, force));
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject != null && other.gameObject.tag.Equals("Ground")) {
            Debug.Log("Morreu");
        }
    }
}
