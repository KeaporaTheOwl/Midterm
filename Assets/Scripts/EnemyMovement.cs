using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody enemyRb;
    private GameObject player;
    [SerializeField] private GameObject enemyProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Adjust firing rate once collider is adjusted.
        Invoke("shootProjectile", 2f);
    }

    void shootProjectile()
    {
        //Shoot towards the player (in progress). Works, but need to adjust the collider.
        Instantiate(enemyProjectilePrefab, transform.position, transform.rotation);
    }
}
