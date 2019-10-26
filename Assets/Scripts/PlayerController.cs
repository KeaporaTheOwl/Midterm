using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float maxSpeed;
    private float xRange = 155;
    private float zRange = 155;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform bombSpawn;
    private bool canShoot = true;
    private int crystalsCollected = 0;
    private Collider shipCollider;
    [SerializeField] private Text bombsCreated;
    private ScoreManager scoreManager;
    public AudioClip shootSound;
    public AudioClip crystalCollectSound;
    public AudioClip bombSound;
    public AudioClip playerDeath;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        shipCollider = GetComponentInChildren<Collider>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && crystalsCollected > 0)
        {
            GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, transform.rotation);
            Physics.IgnoreCollision(bomb.GetComponent<Collider>(), shipCollider);
            crystalsCollected--;
            playerAudio.PlayOneShot(bombSound, 1);
            bombsCreated.text = "Bombs: " + crystalsCollected + "/20";
        }

        if (Input.GetKey(KeyCode.Space) && canShoot == true)
        {
            //Maybe adjust firing rate.
            canShoot = false;
            Invoke("ShootProjectile", .15f);
        }

        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

    }

    void ShootProjectile()
    {
        GameObject bullet = Instantiate(projectilePrefab, bulletSpawn.position, transform.rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shipCollider);
        playerAudio.PlayOneShot(shootSound, 1);
        canShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Crystal"))
        {
            if(crystalsCollected < 20)
            {
                Destroy(collision.gameObject);
                crystalsCollected++;
                playerAudio.PlayOneShot(crystalCollectSound, 1);
                bombsCreated.text = "Bombs: " + crystalsCollected + "/20";
                scoreManager.CrystalScoring();
            }
            else if(crystalsCollected <= 20)
            {
                Destroy(collision.gameObject);
                scoreManager.CrystalScoring();
            }

        }
        else if(collision.gameObject.CompareTag("Projectile"))
        {
            //Problem. Need to make sound play even after player dies. Same with particle effects.
            playerAudio.PlayOneShot(playerDeath, 1);
            explosionParticle.Play();
            Destroy(gameObject);
        }
    }
}
