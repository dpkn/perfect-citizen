using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    public AudioSource deathSound;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            deathSound.Play(); 
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject,0.5f);
    }
}
