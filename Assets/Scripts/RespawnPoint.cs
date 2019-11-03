using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private float rangeX = 150;
    private float rangeZ = 150;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(Random.Range(-rangeX, rangeX), 0, Random.Range(-rangeZ, rangeZ));
        transform.position = startPos;
        InvokeRepeating("RandomizeRespawn", 0, 2);
    }

    private void RandomizeRespawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(-rangeX, rangeX), 0, Random.Range(-rangeZ, rangeZ));
        transform.position = randomPos;
    }
}
