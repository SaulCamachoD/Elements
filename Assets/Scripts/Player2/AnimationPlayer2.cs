using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer2 : MonoBehaviour
{
    public Animator animator;
    public ActionPlayer2 actionPlayer2;
    public HeatlhDeath2 heatlhDeath2;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {   //Obtener variables de otros scripts
        bool Grounded = actionPlayer2.Grounded;
        bool isDeath = heatlhDeath2.isDeath;
        bool Hit = heatlhDeath2.Hit;

        //Control de todas las animaciones
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && Grounded)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && Grounded)
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && Grounded)
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && Grounded)
        {
            animator.SetTrigger("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && Grounded)
        {
            animator.SetTrigger("SuperAttack");
        }
        if (isDeath)
        {
           animator.SetTrigger("Death");
        }
        else if (Hit)
        {
            animator.SetTrigger("Hit");
            heatlhDeath2.Hit = false;
        }


    }
}
