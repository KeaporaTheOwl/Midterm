using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalDestruction : MonoBehaviour
{
    private int healthPool;
    private int hitsTaken;
    private int dropOne;
    private int dropTwo;
    private int dropPowerup;
    [SerializeField] private GameObject crystalDrop;
    [SerializeField] private GameObject powerup;
    private ScoreManager scoreManager;
    private bool firstDrop = false;
    private bool secondDrop = false;
    private AudioSource asteroidAudio;
    [SerializeField] private AudioClip crystalOneSound;
    [SerializeField] private AudioClip crystalTwoSound;
    [SerializeField] private AudioClip asteroidDestruction;
    [SerializeField] private ParticleSystem asteroidExplosion;
    [SerializeField] private GameObject asteroidModel;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        healthPool = Random.Range(2, 8);
        dropOne = Random.Range(1, 3);
        dropTwo = Random.Range(4, 7);
        asteroidAudio = GetComponent<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level 2")
        {
            dropPowerup = Random.Range(1, 11);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstDrop == false && hitsTaken == dropOne)
        {
            DropCrystal();
            firstDrop = true;
            asteroidAudio.PlayOneShot(crystalOneSound, 1);
        }

        if (secondDrop == false && hitsTaken == dropTwo)
        {
            DropCrystal();
            secondDrop = true;
            asteroidAudio.PlayOneShot(crystalTwoSound, 1);
        }

        if (healthPool == hitsTaken)
        {
            if(dropPowerup == 1)
            {
                SpawnPowerup();
            }

            Destroy(gameObject, 5);
            scoreManager.AsteroidScoring();
            asteroidModel.SetActive(false);
            asteroidExplosion.Play();
            asteroidAudio.PlayOneShot(asteroidDestruction, 1);
            gameObject.GetComponent<CrystalDestruction>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hitsTaken++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            hitsTaken++;
            Destroy(collision.gameObject);
        }
    }

    private void DropCrystal()
    {
        Instantiate(crystalDrop, transform.position, transform.rotation);
    }

    private void SpawnPowerup()
    {
        Instantiate(powerup, transform.position, transform.rotation);
    }
}