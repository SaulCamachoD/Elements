using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upHealth2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            HeatlhDeath2 healthCure = other.GetComponent<HeatlhDeath2>();

            if (healthCure != null)
            {
                healthCure.cure(50f);
                Destroy(gameObject);
                print("te curaste");
            }
        }
    }
}
