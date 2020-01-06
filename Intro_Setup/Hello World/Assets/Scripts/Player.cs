using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator     anim;
    public Rigidbody2D  playerRbody;
    private bool        walk;

    private float       horizontal;
    public float       velocity;

    public float jumpForce;
    private bool lookingRight;

    public bool touchingWall;
    public bool steppingFloor;
    public Transform groundCheck;

    public LayerMask whatIsGround;

    void Start() {
        
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");

        steppingFloor = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);

        if (Input.GetButtonDown("Jump") && steppingFloor) {
            playerRbody.AddForce(new Vector2(0, jumpForce));
        }

        if ((horizontal > 0 && lookingRight) || (horizontal < 0 && !lookingRight)) {
            Flip();
        }

        if (!touchingWall) {
            playerRbody.velocity = new Vector2(horizontal * velocity, playerRbody.velocity.y);
        }

        if (!horizontal.Equals(0)) {
            walk = true;
        } else {
            walk = false;
        }

        anim.SetBool("isWalking", walk);
        anim.SetBool("isSteppingGround", steppingFloor);
        anim.SetFloat("velY", playerRbody.velocity.y);
    }

    void Flip() {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision) { //AO ENTRAR EM COLISAO COM COLLISION
        
    }

    private void OnCollisionExit2D(Collision2D collision) { //AO SAIR DE COLISAO COM COLLISION
       // steppingFloor = false;
    }

    private void OnCollisionStay2D(Collision2D collision) { //ENQUANTO COLIDE COM COLLISION
      //  if (collision.gameObject.tag.Equals("Floor")) {
      //      steppingFloor = true;
      //  }
    }

    private void OnTriggerEnter2D(Collider2D collision) { //AO ENTRAR EM COLISAO COM COLLIDER (TRIGGER)
        
    }

    private void OnTriggerExit2D(Collider2D collision) { //AO SAIR DE COLISAO COM COLLIDER (TRIGGER)
        touchingWall = false;
    }

    private void OnTriggerStay2D(Collider2D collision) { //ENQUANTO COLIDE COM COLLIDER (TRIGGER)
        if (!collision.isTrigger && !collision.gameObject.tag.Equals("Bloco")) {
            touchingWall = true;
        }
    }
}
