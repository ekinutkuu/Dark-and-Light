using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    [SerializeField] float attackRange = 0.8f;
    [SerializeField] float enemyDamage = 1;
    [SerializeField] float attackCooldown = 3.0f;
    public Transform player;
    Animator animator;
    PlayerHealth playerHealth;
    bool canAttack = true;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            
            if (distance <= attackRange && canAttack)
            {
                animator.SetTrigger("attack");
                StartCoroutine(PerformAttack());
            }
        }
    }

    private IEnumerator PerformAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);

        playerHealth.TakeDamage(enemyDamage);
        print("player hasar aldý!");

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
