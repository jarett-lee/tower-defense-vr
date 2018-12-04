using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;

        // TODO do better sound
        GameObject soundGameObject = new GameObject();
        soundGameObject.transform.position = transform.position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Sound/Warp") as AudioClip;
        audioSource.Play();
        Destroy(soundGameObject, 5f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        // GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);

        // TODO do better sound
        GameObject soundGameObject = new GameObject();
        soundGameObject.transform.position = transform.position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Sound/Explosion") as AudioClip;
        audioSource.Play();
        Destroy(soundGameObject, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
