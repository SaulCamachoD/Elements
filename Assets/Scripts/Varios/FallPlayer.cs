using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayer : MonoBehaviour
{
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            HealthDeath healthTakeDamage = playerObject.GetComponent<HealthDeath>();

            if (healthTakeDamage != null)
            {
                
                healthTakeDamage.TakeDamage(30f); 
            }

            playerObject.SendMessage("putInInicialPosition");
            print("Caiste");
        }
    }
}
