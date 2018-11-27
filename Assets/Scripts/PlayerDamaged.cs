using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public int hitPoints = 10;
    private int currentHitPoints;
    public GameObject explosionPrefab;

    // Use this for initialization
    void Start()
    {
        currentHitPoints = hitPoints;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("EnemyBullet"))
        {
            currentHitPoints--;
            Destroy(col.gameObject);
        }
        if (currentHitPoints <= 0)
        {
            explosionPrefab = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
