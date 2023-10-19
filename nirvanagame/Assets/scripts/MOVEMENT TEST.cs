using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENTTEST : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public AudioSource src;
    public AudioClip shoot;

    public KeyCode leftKey = KeyCode.A; // Define the key for moving left
    public KeyCode rightKey = KeyCode.D; // Define the key for moving right
    public KeyCode jumpKey = KeyCode.W; // Define the key for jumping
    public KeyCode throwBallKey = KeyCode.Space; // Define the key for throwing a snowball

    public SpriteRenderer spriteRenderer;

    private Rigidbody2D theRB;
    private Animator anim;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public GameObject snowBall;
    public Transform throwPoint;

    private bool canThrow = true;
    private float lastThrowTime;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    void Update()
    {
        if (canThrow && Input.GetKeyDown(throwBallKey))
        {
            if (Time.time - lastThrowTime >= 2f) // Cooldown time of 2 seconds
            {
                GameObject ballClone = Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
                ballClone.transform.localScale = transform.localScale;
                src.clip = shoot;
                src.Play();
                anim.SetTrigger("throw");
                lastThrowTime = Time.time;
                canThrow = false;
                StartCoroutine(EnableThrow());
            }
        }

        // Check if on ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        // Move the player left or right based on the key inputs
        if (Input.GetKey(leftKey))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(rightKey))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        // Jump if the jump key is pressed and the player is on the ground
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        // ANIMATIONS (You can keep this code for animations)

        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isgrounded", isGrounded);

        // Flip the sprite if moving backward
        if (theRB.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (theRB.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    // Coroutine to re-enable throwing after 2 seconds
    IEnumerator EnableThrow()
    {
        yield return new WaitForSeconds(2f);
        canThrow = true; // Re-enable throwing after cooldown
    }
}