using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    //reference to sword animation
    private Animator swordAnimation;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();


    }

    public void Move(float move)
    {
        animator.SetFloat("Move",Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        if (jumping)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
        swordAnimation.SetTrigger("SwordAnimation");
    }

    public void PlayPlayerDeath()
    {
        animator.SetTrigger("Death");
    }
}
