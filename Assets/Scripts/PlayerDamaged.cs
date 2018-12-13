using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour
{
    public int hitPoints = 10;
    private int currentHitPoints;
    public GameObject explosionPrefab;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;
    private Boolean isDead;
    public Text hitPointText;
    private TimeManager timeManager;

    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimeManager>();
        isDead = false;
        currentHitPoints = hitPoints;
        hitPointText.text = "Hit Points: " + currentHitPoints.ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("EnemyBullet"))
        {
            currentHitPoints--;
            hitPointText.text = "Hit Points: " + currentHitPoints.ToString();
            Destroy(col.gameObject);
        } else if(col.tag.Equals("BossBullet"))
        {
            currentHitPoints-=2;
            hitPointText.text = "Hit Points: " + currentHitPoints.ToString();
            Destroy(col.gameObject);
        }
        if (currentHitPoints <= 0)
        {
            currentHitPoints = 0;
            hitPointText.text = "Hit Points: " + currentHitPoints.ToString();
            explosionPrefab = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
            isDead = true;
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();
            timeManager.playerisDead = true;
            Destroy(gameObject);
        }
    }
}
