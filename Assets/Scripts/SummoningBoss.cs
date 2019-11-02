using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummoningBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private int summoningProgress;
    private int summoningComplete = 15;
    private float summoningTime;
    private float summoningDelay = 5;
    private ScoreManager scoreManager;
    private AudioSource summoningAudio;
    [SerializeField] private AudioClip summoningDamage;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        summoningAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > summoningTime + summoningDelay)
        {
            summoningTime = Time.time;
            summoningProgress++;
            Debug.Log("Summoning Progress: " + summoningProgress + "/" + summoningComplete);
        }

        if(summoningProgress == summoningComplete)
        {
            Instantiate(boss, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            summoningProgress--;
            summoningAudio.PlayOneShot(summoningDamage, 1);
            Destroy(collision.gameObject);
            scoreManager.BossDamageScoring();
        }
        else if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
        else
        {

        }
    }
}
