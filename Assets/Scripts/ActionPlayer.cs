using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 16f;
    private float Movx;
    public bool Grounded;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Movx = Input.GetAxisRaw("Horizontal");

        if(Movx > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        else if (Movx < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.9f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.9f))
        {
            Grounded = true;
            Console.WriteLine("Salta");
        }

        else
        {
            Grounded= false;
            Console.WriteLine("No Salta");
        }

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Movx * speed, rb.velocity.y);
    }
}
