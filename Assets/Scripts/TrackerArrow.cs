using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerArrow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject summoningStation;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        summoningStation = GameObject.Find("Summoning Station");
        boss = GameObject.FindGameObjectWithTag("Boss");
        transform.position = player.transform.position + new Vector3(0, 5, 9);

        if (summoningStation == null)
        {
            Vector3 targetPosition = new Vector3(boss.transform.position.x, transform.position.y, boss.transform.position.z);
            transform.LookAt(targetPosition);
        }
        else
        {
            Vector3 targetPosition = new Vector3(summoningStation.transform.position.x, transform.position.y, summoningStation.transform.position.z);
            transform.LookAt(targetPosition);
        }
    }
}
