using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    private float spawnRate = 10f;
    float nextSpawn = 0.0f;
    int count = 0;

    Vector2[] spawnPosition;

    private EnemyFollow enemyFollow;   
    // Use this for initialization
    void Start()
    {
        spawnPosition = new Vector2[4];
        spawnPosition[0] = new Vector2(-16, 7);
        spawnPosition[1] = new Vector2(15, 7);
        spawnPosition[2] = new Vector2(-16, -8);
        spawnPosition[3] = new Vector2(15, -8);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (count < spawnPosition.Length)
            {
                nextSpawn = Time.time + spawnRate;
                // randX = Random.Range(-17f, 16f);
                // randY = Random.Range(8f, -9f);
                whereToSpawn = spawnPosition[count];
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
                count++;
            }
        }

    }
}
