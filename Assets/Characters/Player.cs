using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, rotation_speed;
    //public bool walking;
    public Transform playerTrans;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("Running");
            playerAnim.ResetTrigger("Idle");
            //walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("Running");
            playerAnim.SetTrigger("Idle");
            //walking = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotation_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotation_speed * Time.deltaTime, 0);
        }
    }
}