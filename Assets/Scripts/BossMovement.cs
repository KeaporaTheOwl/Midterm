using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour
{
    private int bossHealth = 15;
    [SerializeField] private float bossSpeed;
    private Rigidbody bossRb;
    private GameObject player;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        bossRb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth == 0)
        {
            Destroy(gameObject);
            scoreManager.BossDestructionScoring();
            Debug.Log("Boss Destroyed");
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        bossRb.AddForce(lookDirection * bossSpeed);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            bossHealth--;
            Destroy(collision.gameObject);
            scoreManager.BossDamageScoring();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
