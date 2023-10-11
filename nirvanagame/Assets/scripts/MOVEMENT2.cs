using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MOVEMENT1 : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    public SpriteRenderer spriteRenderer;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    public GameObject snowBall;
    public Transform throwPoint;

    public float throwForce;

    private Animator anim;
    void Start()

    {
        //Identify the rigidbody
        theRB = GetComponent<Rigidbody2D>();
        //Identify the animator and animations
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(throwBall))
        {

            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            //Gör så att projektilen kommer fram på throwpoint när kastknappen är nedtryckt
            ballClone.transform.localScale = transform.localScale;
            //Gör så att bollen åker åt det håll man kollar åt
            anim.SetTrigger("throw");
        }

        //Check if on ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        //Left and right
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        //Jump
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        //ANIMATIONS

        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        //Mathf to ignore minus
        anim.SetBool("isgrounded", isGrounded);

        // Get the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        theRB.velocity = new Vector2(horizontalInput * moveSpeed, theRB.velocity.y);

        // Flip the sprite if moving backward
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

}