using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   

    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;

    public PlayerHealth playerHealth;

    void Start()
    {
        maxHealth = playerHealth.Health;
        healthSlider.maxValue = maxHealth;
    }

    void Update()
    {
        currentHealth = playerHealth.Health;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(1);
            Debug.Log("max health: "+maxHealth);
            Debug.Log("health: "+ currentHealth);
        }
        */
    }
}
