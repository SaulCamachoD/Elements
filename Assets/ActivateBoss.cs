using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ActivateBoss : MonoBehaviour
{
    public GameObject FinalBoss; // Referencia al GameObject del Boss

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Activar el GameObject del Boss si está desactivado
            if (FinalBoss != null && !FinalBoss.activeSelf)
            {
                FinalBoss.SetActive(true);
            }
        }
    }
}
