using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGravity : MonoBehaviour
{
    public float gravity = -10f;
    private Vector3 velocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = new Vector3(0, 0, 0);
        controller.Move(move * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }
}
