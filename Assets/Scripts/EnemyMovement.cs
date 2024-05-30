using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    public float triggerDistance = 5f;

    [SerializeField] float Speed = 10.0f;
    CharacterController controller;

    Animator animator;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= triggerDistance)
            {
                animator.SetFloat("moveAnim", Speed);

                Vector3 direction = player.position - transform.position;

                direction.Normalize();

                direction.y = 0;
                transform.rotation = Quaternion.LookRotation(direction);

                controller.Move(direction * Speed * Time.deltaTime);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            animator.SetFloat("moveAnim", 0f);
        }
    }
}
