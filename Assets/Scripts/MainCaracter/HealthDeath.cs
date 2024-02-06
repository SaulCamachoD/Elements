using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthDeath : MonoBehaviour
{
    [SerializeField] private float Health;
    public bool isDeath;
    public bool Hit;
 

    //Control de animacion de muerte que se envia al script de animacion
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
            ReceiveHit();   
        } 
    }

    //Control de animacion de golpe recibido y se envia a script de animacion
    public void ReceiveHit()
    {
        Hit = true;
    }

}
