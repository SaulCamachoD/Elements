using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform ControAttack;
    [SerializeField] private float RadiusHit;
    [SerializeField] private float DamageHitOne;
    [SerializeField] private float DamageHitTwo;
    [SerializeField] private float DamageHitThree;
    [SerializeField] private float TimeBettwenHit;
    [SerializeField] private float TimeToNextHit;
    

    private void Update()
    {
        if (TimeToNextHit > 0) 
        {
            TimeToNextHit -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && TimeToNextHit <= 0)
        {
            Hit(DamageHitOne);
            TimeToNextHit = TimeBettwenHit; 
        }
        if (Input.GetButtonDown("Fire2") && TimeToNextHit <= 0)
        {
            Hit(DamageHitTwo);
            TimeToNextHit = TimeBettwenHit;
        }
        if (Input.GetButtonDown("Fire3") && TimeToNextHit <= 0)
        {
            Hit(DamageHitThree);
            TimeToNextHit = TimeBettwenHit;
        }
    }
    private void Hit(float damageValor)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(ControAttack.position, RadiusHit);
        
        foreach (Collider2D colicions in objects) 
        {
            if (colicions.CompareTag("FinalBoss")) 
            {
                colicions.transform.GetComponent<FinalBoss>().TakeDamage(damageValor);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControAttack.position, RadiusHit);
    }
}
