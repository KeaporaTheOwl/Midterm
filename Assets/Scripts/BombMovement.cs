using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    private Rigidbody bombRb;
    private GameObject boss;
    private GameObject summoningStation;
    [SerializeField] private float bombSpeed;

    //Just ask about this whole script. It just isn't working.

    // Start is called before the first frame update
    void Start()
    {
        bombRb = GetComponent<Rigidbody>();
        summoningStation = GameObject.Find("Summoning Station");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null)
        {
            float distance = Vector3.Distance(boss.transform.position, transform.position);

            Vector3 lookDirection = (boss.transform.position - transform.position).normalized;
            bombRb.AddForce(lookDirection * bombSpeed);

            Vector3 targetPosition = new Vector3(boss.transform.position.x, transform.position.y, boss.transform.position.z);
            transform.LookAt(targetPosition);
        }
        else
        {
            float distance = Vector3.Distance(summoningStation.transform.position, transform.position);

            Vector3 lookDirection = (summoningStation.transform.position - transform.position).normalized;
            bombRb.AddForce(lookDirection * bombSpeed);

            Vector3 targetPosition = new Vector3(summoningStation.transform.position.x, transform.position.y, summoningStation.transform.position.z);
            transform.LookAt(targetPosition);
        }

    }
}
