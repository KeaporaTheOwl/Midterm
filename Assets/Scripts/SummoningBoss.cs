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

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(collision.gameObject);
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
