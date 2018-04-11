using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Opponent : MonoBehaviour
{

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool walking)
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", walking);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isIdle", false);
        }
    }

    public void Attack(bool attacking)
    {
        if (animator != null)
        {
            animator.SetBool("isAttacking", attacking);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
        }
    }

    public void Idle(bool idle)
    {
        if (animator != null)
        {
            animator.SetBool("isIdle", idle);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
        }
    }
}
