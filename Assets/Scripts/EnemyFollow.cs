using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public GameObject bulletPrefab;
    private Transform target;
    public Transform firePoint;
    public float fireRate = 2f;
    float nextFireTime = 0;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 fireDirection = target.position - transform.position;
            float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Mathf.Infinity);

            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time > nextFireTime)
                {
                    nextFireTime = Time.time + fireRate;
                    Fire();
                }
            }
        }

    }

    public void Fire()
    {
        GameObject bulletIns = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        bulletIns.GetComponent<Rigidbody2D>().velocity = bulletIns.transform.up * 10;
        Destroy(bulletIns, 3);
    }

}
