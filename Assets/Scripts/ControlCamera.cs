using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform target; // Objeto que la cámara seguirá
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento
    public Vector3 offset; // Desplazamiento de la cámara

    private void Start()
    {
        // Inicializar la posición de la cámara
        transform.position = target.position + offset;
    }

    private void Update()
    {
        // Seguir al personaje con suavidad
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x , transform.position.y, target.position.z + -3);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
