using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TargetDamaged : MonoBehaviour
{
    public int hitPoints = 2;
    private int currentHitPoints;
    public GameObject explosionPrefab;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;

    public Text text;

    [HideInInspector]
    public Boolean isDead;

    // Use this for initialization
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Bullet"))
        {
            currentHitPoints--;
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
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
