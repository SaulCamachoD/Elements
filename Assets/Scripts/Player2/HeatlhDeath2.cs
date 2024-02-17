using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlhDeath2 : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HeatlhBar2 heatlhBar2;
    public event EventHandler PlayerDeath;
    public bool isDeath;
    public bool Hit;

    private void Start()
    {
        Health = maxHealth;
        heatlhBar2.starHealthBar2(Health);
    }
    //Control de animacion de muerte que se envia al script de animacion
    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        heatlhBar2.changeActualHealth2(Health);
        if (Health <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            isDeath = true;
        }

        else
        {
            isDeath = false;
            ReceiveHit();
        }
    }
    public void cure(float upHealth)
    {
        Health += upHealth;
        if (Health >= 100f)
        {
            Health = 100f;
        }
        heatlhBar2.changeActualHealth2(Health);
    }

    public void ReceiveHit()
    {
        Hit = true;
    }
}
