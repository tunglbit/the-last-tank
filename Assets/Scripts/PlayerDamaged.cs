using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    public int hitPoints = 10;
    private int currentHitPoints;
    public GameObject explosionPrefab;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;
    public Boolean isDead;
    public Text hitPointText;

    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    void Start()
    {
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
            currentHitPoints-=3;
            hitPointText.text = "Hit Points: " + currentHitPoints.ToString();
            Destroy(col.gameObject);
        }
        if (currentHitPoints <= 0)
        {
            explosionPrefab = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
            isDead = true;
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
