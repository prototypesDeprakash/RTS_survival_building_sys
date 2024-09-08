using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class zombie_health : MonoBehaviour
{
    public int currentHealth = 100;  // Starting health of the zombie
    public Animator animator;
    public Slider healthbar;
    private int maxHealth = 1000;  // Max health value

    private void Start()
    {
        // Initialize the health bar value
        healthbar.maxValue = maxHealth;
        healthbar.value = currentHealth;
    }

    private void Update()
    {
        // Update the health bar to reflect current health

        // i dont know why i get object ref not set to ins of obj err, so im putting this shit in try catch -
        try{
            healthbar.value = currentHealth;
        }
        catch(Exception e){
            Debug.Log("I dont care");
        }
        

        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetBool("dead", true);
            Debug.Log("dead");
        }
    }

    public void TakeDamage(int damage)
    {
        // Decrease current health by damage amount
        currentHealth -= damage;
        // Ensure health does not drop below zero
        currentHealth = Mathf.Max(currentHealth, 0);
        // Optionally, you can update the health bar here if you want to reflect damage immediately
        healthbar.value = currentHealth;
    }
}