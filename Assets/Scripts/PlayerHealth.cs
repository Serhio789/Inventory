using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private Animator animator;
    private PlayerMovement playerMovement;
    private int previousLevel = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        maxHealth *= previousLevel;
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Healing(float healPoint) => currentHealth += healPoint;
    private void Die()
    {
        animator.SetBool("Die", true);
        Destroy(playerMovement);
    }
    public float CurrentHealth() => currentHealth;
}
