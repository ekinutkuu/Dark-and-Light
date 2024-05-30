using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    Animator animator;
    PlayerController controller;
    //DamageDealer damageDealer;

    public bool isAttacking = false;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        //damageDealer = GetComponent<DamageDealer>();
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
            Invoke("ResetMoveAnimation", 1.5f); //animation speed 1 olduðu zaman invoke 2
        }
    }

    void ResetMoveAnimation()
    {
        animator.SetFloat("moveAnim", controller.moveAmount);
        isAttacking = false;
    }

    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponHolder;
    //GameObject weaponInHand;
    public void StartDealDamage()
    {
        //damageDealer.StartDealDamage();

        //weaponInHand = Instantiate(weapon);
        //weaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();

        DamageDealer damageDealer = weapon.GetComponentInChildren<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.StartDealDamage();
        }
    }

    public void EndDealDamage()
    {
        //damageDealer.EndDealDamage();

        //weaponInHand = Instantiate(weapon, weaponHolder.transform);
        //weaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();

        DamageDealer damageDealer = weapon.GetComponentInChildren<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.EndDealDamage();
        }
    }
    

}
