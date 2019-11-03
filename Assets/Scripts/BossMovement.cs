using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    private int bossHealth = 15;
    private float bossSpeed = 15f;
    private Rigidbody bossRb;
    private GameObject player;
    private ScoreManager scoreManager;
    private AudioSource bossAudio;
    [SerializeField] private AudioClip bossDamaged;
    [SerializeField] private AudioClip bossDestroyed;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private GameObject bossModel;
    [SerializeField] private ParticleSystem bossExplosion;

    // Start is called before the first frame update
    void Start()
    {
        bossRb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        scoreManager = FindObjectOfType<ScoreManager>();
        bossAudio = GetComponent<AudioSource>();
        bossAudio.PlayOneShot(spawnSound, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth == 0)
        {
            Destroy(gameObject, 5);
            scoreManager.BossDestructionScoring();
            bossModel.SetActive(false);
            gameObject.GetComponent<BossMovement>().enabled = false;
            bossAudio.PlayOneShot(bossDestroyed, 1);
            bossExplosion.Play();
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            GameObject[] allCrystals = GameObject.FindGameObjectsWithTag("Crystal");
            Invoke("GameOver", 3);

            foreach (GameObject enemy in allEnemies)
            {
                Destroy(enemy);
            }

            foreach (GameObject asteroid in allAsteroids)
            {
                Destroy(asteroid);
            }

            foreach (GameObject crystal in allCrystals)
            {
                Destroy(crystal);
            }
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        bossRb.AddForce(lookDirection * bossSpeed);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            bossHealth--;
            Destroy(collision.gameObject);
            scoreManager.BossDamageScoring();
            bossAudio.PlayOneShot(bossDamaged, 1);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Crystal"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}