using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float maxSpeed;
    [SerializeField] private GameObject projectilePrefab;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ask about this. Problem I'm having is that the editor runs like crap when off of my charger, which makes the game slow.
        //If I change to time.deltatime to fix it being based off frame rate, it runs at a snail's pace. Works fine at plugged in speed.
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * forwardInput, ForceMode.VelocityChange);

        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localRotation = Quaternion.Euler(0.0f, 315.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localRotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localRotation = Quaternion.Euler(0.0f, 225.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localRotation = Quaternion.Euler(0.0f, 135.0f, 0.0f);
            }
        }

        if(Input.GetKey(KeyCode.Space) && canShoot == true)
        {
            //Maybe adjust firing rate. Also ask about how to make the bullets appear slightly in front of the player, since currently
            //I would end up shooting myself with my own projectile. The enemy would too.
            canShoot = false;
            Invoke("shootProjectile", .15f);
        }

        if (playerRb.velocity.magnitude > maxSpeed)
        {
            //playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxSpeed);
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }

    }

    void shootProjectile()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        canShoot = true;
    }

}
