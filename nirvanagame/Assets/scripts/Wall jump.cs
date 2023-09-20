using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallJump : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float moveSpeed = 8f, jumpForce = 700f; //jumpForce is how far he jumps off the wall
    bool jumpAllowed, wallJumpAllowed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        if (rb.velocity.y == 0 || wallJumpAllowed)
            jumpAllowed = true;
        else
            jumpAllowed = false;
        if (Input.GetKeyDown("Jump") && jumpAllowed)
            DoJump();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
    void DoJump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            wallJumpAllowed = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
            wallJumpAllowed = false;
    }
}