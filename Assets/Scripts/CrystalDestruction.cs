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
    private bool firstDrop = false;
    private bool secondDrop = false;

    // Start is called before the first frame update
    void Start()
    {
        healthPool = Random.Range(2, 8);
        dropOne = Random.Range(1, 3);
        dropTwo = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstDrop == false && hitsTaken == dropOne)
        {
            dropCrystal();
            firstDrop = true;
        }

        if(secondDrop == false && hitsTaken == dropTwo)
        {
            dropCrystal();
            secondDrop = true;
        }

        if(healthPool == hitsTaken)
        {
            Destroy(gameObject);
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

    void dropCrystal()
    {
        Instantiate(crystalDrop, transform.position, transform.rotation);
    }
}
