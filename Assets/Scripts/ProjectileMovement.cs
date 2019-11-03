using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float projectileSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * projectileSpeed, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}