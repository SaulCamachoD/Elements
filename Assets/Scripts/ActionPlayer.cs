using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 20;
    private float Movx;
    public Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
       Movx = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Movx * speed, rb.velocity.y);
    }
}
