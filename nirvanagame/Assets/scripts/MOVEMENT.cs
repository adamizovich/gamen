using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MOVEMENT : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;
    public KeyCode throwBall2;

    public SpriteRenderer spriteRenderer;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    public GameObject snowBall;
    public Transform throwPoint;

    //new
    public GameObject snowBall2;
    public Transform throwPoint2;

    //newer
    private bool canThrow = true;
    private float lastThrowTime;

    private bool canThrow2 = true;
    private float lastThrowTime2;

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

        if (canThrow && Input.GetKeyDown(throwBall))
        {
            // Check if enough time has passed since the last throw
            if (Time.time - lastThrowTime >= 2f) // Cooldown time of 2 seconds
            {
                GameObject ballClone = Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
                ballClone.transform.localScale = transform.localScale;
                anim.SetTrigger("throw");
                lastThrowTime = Time.time;
                canThrow = false; // Disable further throws
                StartCoroutine(EnableThrow());
            }
        }
    

    // Coroutine to re-enable throwing after 2 seconds
     IEnumerator EnableThrow()
     {
         yield return new WaitForSeconds(2f);
        canThrow = true; // Re-enable throwing after cooldown
     }


       if (canThrow && Input.GetKeyDown(throwBall2))
        {
            if (Time.time - lastThrowTime2 >= 2f)
            {
                GameObject ballClone2 = Instantiate(snowBall2, throwPoint2.position, throwPoint2.rotation);
                ballClone2.transform.localScale = transform.localScale;
                anim.SetTrigger("throw");
                lastThrowTime2 = Time.time;
                canThrow = false;
                StartCoroutine(EnableThrow2());
            }
        }

        IEnumerator EnableThrow2()
        {
            yield return new WaitForSeconds(2f);
            canThrow = true; // Re-enable throwing after cooldown
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
