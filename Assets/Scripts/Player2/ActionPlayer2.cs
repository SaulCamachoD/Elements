using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer2 : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 16f;
    public float backForce = 5f;
    public bool impulse;
    private float Movx;
    public bool Grounded;
    private Rigidbody2D rb;
    public float impulseDuration = 0.5f;
    private float impulseTimer = 0f;
    public float Xinicial;
    private float Yinicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Xinicial = transform.position.x;
        Yinicial = transform.position.y;
    }
    void Update()
    {
        impulseBack();

        if (!impulse)
        {
            Movx = Input.GetAxisRaw("Horizontal1");


            //Condicion para que el personaje gire de derecha a izquierda
            if (Movx > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else if (Movx < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

            //Dibuja un raycasy para saltar solo en el suelo
            Debug.DrawRay(transform.position, Vector3.down * 0.9f, Color.red);
            if (Physics2D.Raycast(transform.position, Vector3.down, 0.9f))
            {
                Grounded = true;

            }

            else
            {
                Grounded = false;

            }

            if (Input.GetKey(KeyCode.Keypad0) && Grounded)
            {
                Jump();
            }

        }


    }
    //Funcion de salto
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        if (!impulse)
        {
            //Mover el personaje en el eje X
            rb.velocity = new Vector2(Movx * speed, rb.velocity.y);
        }
    }

    //Funcion para que cuando reciba un golpe haga un empujon
    void impulseBack()
    {
        if (impulse)
        {
            transform.Translate(Vector3.right * backForce * Time.deltaTime, Space.World);
            impulseTimer += Time.deltaTime;

            //Timporizador para desactivar Impulse y reiniciar temporizador
            if (impulseTimer >= impulseDuration)
            {
                impulse = false;
                impulseTimer = 0f;
            }
        }
    }
    public void putInInicialPosition()
    {
        transform.position = new Vector3(Xinicial, Yinicial, 0);
    }
}
