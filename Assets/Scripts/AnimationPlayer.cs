using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator animator;
    public ActionPlayer ActionPlayer;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        bool Grounded = ActionPlayer.Grounded;
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && Grounded)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.E) && Grounded)
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.R) && Grounded)
        {
            animator.SetTrigger("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.F) && Grounded)
        {
            animator.SetTrigger("SuperAttack");
        }

        
    }
}
