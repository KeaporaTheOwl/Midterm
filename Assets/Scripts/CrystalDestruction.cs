using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDestruction : MonoBehaviour
{
    private int healthPool;

    // Start is called before the first frame update
    void Start()
    {
        healthPool = Random.Range(2, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPool == 0)
        {
            Destroy(gameObject);
        }
    }

    //Possibly change to OnCollisionEnter once I fix the bullets affecting the player.
    private void OnTriggerEnter(Collider other)
    {
        healthPool--;
    }
}
