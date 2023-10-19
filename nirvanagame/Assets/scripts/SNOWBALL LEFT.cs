using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SNOWBALLLEFT : MonoBehaviour
    {
        public float ballSpeed;

        public Rigidbody2D theRB;

        public GameObject snowBallEffect;

        void Start()
        {
            theRB = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Instantiate(snowBallEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }




