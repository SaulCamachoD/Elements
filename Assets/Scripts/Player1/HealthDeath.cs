using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthDeath : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HeatlhBar heatlhBar;
    public event EventHandler PlayerDeath;
    public bool isDeath;
    public bool Hit;

    private void Start()
    {
        Health = maxHealth;
        heatlhBar.starHealthBar(Health);
    }
    //Control de animacion de muerte que se envia al script de animacion
    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        heatlhBar.changeActualHealth(Health);
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
        heatlhBar.changeActualHealth(Health);
    }
    
    public void ReceiveHit()
    {
        Hit = true;
    }

}
