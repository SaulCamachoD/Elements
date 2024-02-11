using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField]private Vector2 speedBackground;

    private Vector2 offSet;
    private Material material;
    private Rigidbody2D PlayerRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        PlayerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        offSet = (PlayerRB.velocity * 0.1f) * speedBackground *Time.deltaTime;
        material.mainTextureOffset += offSet;
    }
}
