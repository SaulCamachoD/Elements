using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.CompareTag("Player"))
            {
                HealthDeath healthCure = other.GetComponent<HealthDeath>();

                if (healthCure != null)
                {
                    healthCure.cure(50f);
                    Destroy(gameObject);
                    print("te curaste");
                }
            }
        }
    }
}