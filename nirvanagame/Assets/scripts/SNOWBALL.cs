using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNOWBALL : MonoBehaviour
{
    public float ballSpeed;

    private Rigidbody2D theRB;

    void Start()
    {
        theRB.velocity = transform.right * ballSpeed;
    }

    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}




