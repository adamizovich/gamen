using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float takeoff = 16f;
    private bool facingright = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    
   

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
}
