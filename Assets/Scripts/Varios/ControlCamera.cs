using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControlCamera : MonoBehaviour
{
    public Transform target; // Objeto que la c�mara seguir�
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento
    public Vector3 offset; // Desplazamiento de la c�mara

    private Vector3 initialPosition;

    private void Start()
    {
        // Guardar la posici�n inicial de la c�mara
        initialPosition = transform.position;
        // Ajustar la posici�n inicial en el eje Y
        initialPosition.y += 3;

    }

    private void Update()
    {
        // Seguir al personaje en los ejes X y Z con suavidad
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, target.position.z + offset.z - 3);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
