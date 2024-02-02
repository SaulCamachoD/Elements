using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 20;
    private float Movx;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Movx = Input.GetAxisRaw("Horizontal");


        if (Input.GetKey(KeyCode.Space))
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
