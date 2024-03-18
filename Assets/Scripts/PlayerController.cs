using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 500.0f;

    public float moveAmount;
    bool isAttacking;
    
    Quaternion targetRotation;

    CameraController cameraController;
    CharacterController characterController;
    PlayerCombat playerCombat;
    Animator animator;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3(h, 0, v)).normalized;

        var moveDirection = cameraController.PlanerRotation * moveInput;

        isAttacking = playerCombat.isAttacking;
        if (moveAmount > 0 && !isAttacking)
        {
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        animator.SetFloat("moveAnim", moveAmount, 0.2f, Time.deltaTime);

    }
}
