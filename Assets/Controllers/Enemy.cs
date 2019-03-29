using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    public AudioSource deathSound;
    public float addTimeOnKill = 5f;
    private GameController gameController;
    private bool killed = false;

    public void Start()
    {
        gameController = GameController.instance;
    }

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
        if (!killed)
        {
            killed = true;
            Destroy(gameObject, 0.5f);
            gameController.killCount += 1;
            gameController.timeLeft += addTimeOnKill;
        }
    }
}
