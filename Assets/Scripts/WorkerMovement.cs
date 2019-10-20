using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] miningTargets;
    private GameObject closest;
    private Rigidbody workerRb;
    [SerializeField] float workerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        FindClosestAsteroid();
        workerRb = GetComponent<Rigidbody>();
    }

    public GameObject FindClosestAsteroid()
    {
        miningTargets = GameObject.FindGameObjectsWithTag("Asteroid");

        closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in miningTargets)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(closest.transform.position.x, transform.position.y, closest.transform.position.z);
        transform.LookAt(targetPosition);

        Vector3 lookDirection = (closest.transform.position - transform.position).normalized;
        workerRb.AddForce(lookDirection * workerSpeed);
    }
}
