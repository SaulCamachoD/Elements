using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private float health;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageHit)
    {
        health -= damageHit;

        if (health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        animator.SetTrigger("Death");
    }
}
