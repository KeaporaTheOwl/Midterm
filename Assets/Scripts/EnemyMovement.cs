﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    private Rigidbody enemyRb;
    private GameObject player;
    [SerializeField] private GameObject enemyProjectilePrefab;
    private float firingRange = 8f;
    private float reload;
    [SerializeField] private float rateOfFire = 3f;
    [SerializeField] Transform enemyBulletSpawn;
    private Collider enemyShipCollider;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyShipCollider = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);

        if(distance < firingRange && Time.time > reload + rateOfFire)
        {
            reload = Time.time;
            shootProjectile();
        }

    }

    void shootProjectile()
    {
        GameObject enemyBullet = Instantiate(enemyProjectilePrefab, enemyBulletSpawn.position, transform.rotation);
        Physics.IgnoreCollision(enemyBullet.GetComponent<Collider>(), enemyShipCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
