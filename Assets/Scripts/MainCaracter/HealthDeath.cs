using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDeath : MonoBehaviour
{
    [SerializeField] private float Health;
    public bool isDeath;


    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0) 
        {
            isDeath = true;
        }
        else
        {
            isDeath = false;
        }
    }

    
}
