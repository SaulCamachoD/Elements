using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Transform ControAttack;
    [SerializeField] private float RadiusHit;
    [SerializeField] private float DamageHit;
    [SerializeField] private float TimeBettwenHit;
    [SerializeField] private float TimeToNextHit;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (TimeToNextHit > 0)
        {
            TimeToNextHit -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && TimeToNextHit <= 0)
        {
            Hit();
            TimeToNextHit = TimeBettwenHit;
            animator.SetTrigger("Cleave");
        }
    }
    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(ControAttack.position, RadiusHit);

        foreach (Collider2D colicions in objects)
        {
            if (colicions.CompareTag("Player"))
            {
                colicions.transform.GetComponent<HealthDeath>().TakeDamage(DamageHit);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControAttack.position, RadiusHit);
    }
}
