using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float projectileSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * projectileSpeed, Space.World);
    }

    private void OnBecameInvisible()
    {
        //Ask about this. Fix that sometimes it takes a while to "go off screen"
        Destroy(gameObject);
    }

}
