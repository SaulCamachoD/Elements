using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayer : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthDeath healthTakeDamage = other.GetComponent<HealthDeath>();

            if (healthTakeDamage != null)
            {
                healthTakeDamage.TakeDamage(30f);
            }

            other.SendMessage("putInInicialPosition");
            print("Caiste jugador 1");
        }
        else if (other.CompareTag("Player2"))
        {
            HeatlhDeath2 healthTakeDamage2 = other.GetComponent<HeatlhDeath2>();

            if (healthTakeDamage2 != null)
            {
                healthTakeDamage2.TakeDamage(30f);
            }

            other.SendMessage("putInInicialPosition");
            print("Caiste jugador 2");
        }

    }
}

