using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDestruction : MonoBehaviour
{
    private int healthPool;
    private int hitsTaken;
    private int dropOne;
    private int dropTwo;
    [SerializeField] private GameObject crystalDrop;
    private ScoreManager scoreManager;
    private bool firstDrop = false;
    private bool secondDrop = false;
    private AudioSource asteroidAudio;
    public AudioClip crystalOneSound;
    public AudioClip crystalTwoSound;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        healthPool = Random.Range(2, 8);
        dropOne = Random.Range(1, 3);
        dropTwo = Random.Range(4, 7);
        asteroidAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstDrop == false && hitsTaken == dropOne)
        {
            DropCrystal();
            firstDrop = true;
            asteroidAudio.PlayOneShot(crystalOneSound, 1);
        }

        if(secondDrop == false && hitsTaken == dropTwo)
        {
            DropCrystal();
            secondDrop = true;
            asteroidAudio.PlayOneShot(crystalTwoSound, 1);
        }

        if(healthPool == hitsTaken)
        {
            Destroy(gameObject);
            scoreManager.AsteroidScoring();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            hitsTaken++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Bomb"))
        {
            hitsTaken++;
            Destroy(collision.gameObject);
        }
    }

    void DropCrystal()
    {
        Instantiate(crystalDrop, transform.position, transform.rotation);
    }
}
