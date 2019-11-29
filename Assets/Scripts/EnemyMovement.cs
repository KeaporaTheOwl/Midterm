using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed = 5f;
    private Rigidbody enemyRb;
    private GameObject player;
    [SerializeField] private GameObject enemyProjectilePrefab;
    private float firingRange = 8f;
    private float reload;
    private float rateOfFire = 3f;
    [SerializeField] Transform enemyBulletSpawn;
    private Collider enemyShipCollider;
    private ScoreManager scoreManager;
    private AudioSource enemyAudio;
    [SerializeField] private AudioClip enemyShootSound;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private GameObject enemyShipModel;
    [SerializeField] private ParticleSystem explosionParticle;
    private bool isTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyShipCollider = GetComponentInChildren<Collider>();
        scoreManager = FindObjectOfType<ScoreManager>();
        enemyAudio = GetComponent<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Tutorial")
        {
            isTutorial = true;
        }
        else
        {
            isTutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);

        if (isTutorial == false && distance < firingRange && Time.time > reload + rateOfFire)
        {
            reload = Time.time;
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject enemyBullet = Instantiate(enemyProjectilePrefab, enemyBulletSpawn.position, transform.rotation);
        Physics.IgnoreCollision(enemyBullet.GetComponent<Collider>(), enemyShipCollider);
        enemyAudio.PlayOneShot(enemyShootSound, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject, 5);
            Destroy(collision.gameObject);
            scoreManager.EnemyScoring();
            enemyShipModel.SetActive(false);
            explosionParticle.Play();
            enemyAudio.PlayOneShot(enemyDeath, 1);
            gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject, 5);
            Destroy(collision.gameObject);
            scoreManager.EnemyScoring();
            enemyShipModel.SetActive(false);
            explosionParticle.Play();
            enemyAudio.PlayOneShot(enemyDeath, 1);
            gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("Crystal"))
        {
            Destroy(collision.gameObject);
        }
    }
}