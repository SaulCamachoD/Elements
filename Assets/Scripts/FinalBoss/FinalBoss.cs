using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public Rigidbody2D rb;
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        float DistancePlayer = Vector2.Distance(transform.position, player.position );
        animator.SetFloat("DistancePlayer", DistancePlayer);
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
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControAttack.position, RadiusHit);
    }

    public void LookPlayer()
    {
        if((player.position.x > transform.position.x && !lookRight) || (player.position.x < transform.position.x && lookRight))
        {
            lookRight = !lookRight;
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180, 0f);
        }
    }
}
