using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNOWBALLLEFT : MonoBehaviour
{
    public float ballSpeed;

    private Rigidbody2D theRB;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        theRB.velocity = new Vector2(-ballSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

}
