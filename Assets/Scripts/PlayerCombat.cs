using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    Animator animator;
    PlayerController controller;

    public bool isAttacking = false;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }

    }

    void Attack()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("SwordAttack");
            animator.SetFloat("moveAnim", 0f);
            Invoke("ResetMoveAnimation", 2);
        }
    }

    void ResetMoveAnimation()
    {
        animator.SetFloat("moveAnim", controller.moveAmount);
        isAttacking = false;
    }

}
