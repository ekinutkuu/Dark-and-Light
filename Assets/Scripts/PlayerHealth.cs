using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health = 20;

    void Start()
    {
    }

    public float Health
    {
        get { return health; }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        WinLoseManager.loseGame();
    }

}
