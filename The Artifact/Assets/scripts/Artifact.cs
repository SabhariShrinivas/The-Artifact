using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int bleed = 2;
    private AudioSource audioSource;
    private float bleedTimer;
    private PlayerBackPack playerBackPack;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerBackPack = FindObjectOfType<PlayerBackPack>();
        health = maxHealth;
        bleedTimer = Time.time;
    }
    private void Update()
    {
        if(Time.time > bleedTimer)
        {
            health -= bleed;
            bleedTimer = Time.time + 1f;
        }
        CheckHealth();
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            GameOverUIController.instance.GameOver("Save the damn artifact CJ");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(playerBackPack.currentNumberOfFruits != 0)
            {
                audioSource.Play();
                health += playerBackPack.TakeFruit();
            }
            if(health >= maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
