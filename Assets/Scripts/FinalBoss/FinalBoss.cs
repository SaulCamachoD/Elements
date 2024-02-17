using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Transform ControAttack;
    [SerializeField] private float RadiusHit;
    [SerializeField] private float DamageHit;
    [SerializeField] private float TimeBettwenHit;
    [SerializeField] private float TimeToNextHit;
    private bool lookRight = false;
    public Transform player;
    public Transform Player2;
    public Rigidbody2D rb;
    public Animator animator;
    private float player1Distance;
    private float player2Distance;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        animator.SetTrigger("Death");
    }

    private void Update()
    {
        player1Distance = Vector2.Distance(transform.position, player.position);
        player2Distance = Vector2.Distance(transform.position, Player2.position);
        animator.SetFloat("DistancePlayer", player1Distance);
        animator.SetFloat("DistancePlayer2", player2Distance);

    }
    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(ControAttack.position, RadiusHit);

        foreach (Collider2D colicions in objects)
        {
            if (colicions.CompareTag("Player"))
            {
                colicions.transform.GetComponent<HealthDeath>().TakeDamage(DamageHit);
                colicions.GetComponent<ActionPlayer>().impulse = true;

                if (transform.position.x > colicions.transform.position.x)
                {
                    colicions.GetComponent<ActionPlayer>().backForce = -3;
                    colicions.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    colicions.GetComponent<ActionPlayer>().backForce = 3;
                    colicions.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            if (colicions.CompareTag("Player2"))
            {
                colicions.transform.GetComponent<HeatlhDeath2>().TakeDamage(DamageHit);
                colicions.GetComponent<ActionPlayer2>().impulse = true;

                if (transform.position.x > colicions.transform.position.x)
                {
                    colicions.GetComponent<ActionPlayer2>().backForce = -3;
                    colicions.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    colicions.GetComponent<ActionPlayer2>().backForce = 3;
                    colicions.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControAttack.position, RadiusHit);
    }

    public void LookPlayer()
    {
        {
            if (player1Distance < player2Distance)
            {
                if ((player.position.x > transform.position.x && !lookRight) || (player.position.x < transform.position.x && lookRight))
                {
                    lookRight = !lookRight;
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180, 0f);
                }
            }
            else
            {
                if ((Player2.position.x > transform.position.x && !lookRight) || (Player2.position.x < transform.position.x && lookRight))
                {
                    lookRight = !lookRight;
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180, 0f);
                }
            }
        }

    }
}
