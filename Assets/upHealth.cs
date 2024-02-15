using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject )
        {
            HealthDeath healthCure = playerObject.GetComponent<HealthDeath>();

            if (healthCure)
            {
                healthCure.cure(50f);
                Destroy(gameObject);
            }
            print("te curaste");

        }
    }
}
