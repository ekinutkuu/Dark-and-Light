using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float health = 2;

    GameObject player;
    Animator animator;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("takeDamage");

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }

}
