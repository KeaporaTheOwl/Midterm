using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject asteroid;
    [SerializeField] private GameObject powerup;
    [SerializeField] private Text tutorialText;
    private int xRange = 15;
    private int zRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > zRange)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zRange);
        }

        if(player.transform.position.z < -zRange)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -zRange);
        }

        if (player.transform.position.x > xRange)
        {
            player.transform.position = new Vector3(xRange, player.transform.position.y, player.transform.position.z);
        }

        if (player.transform.position.x < -xRange)
        {
            player.transform.position = new Vector3(-xRange, player.transform.position.y, player.transform.position.z);
        }
    }

    IEnumerator TutorialRoutine()
    {

        tutorialText.text = "Use WASD to move. Aim with the Arrow Keys. Hold Space Bar to shoot.";
        yield return new WaitForSeconds(10);

        tutorialText.text = "Asteroids contain minerals essential to your mission. Shoot them to release the crystals.";
        Instantiate(asteroid, new Vector3(7.5f, 0, 0), transform.rotation);
        yield return new WaitForSeconds(10);

        tutorialText.text = "Pass over a crystal to collect it and create a bomb.";
        yield return new WaitForSeconds(10);

        tutorialText.text = "Enemies will pursue you at all times. Shoot them to destroy them.";
        Instantiate(enemy, new Vector3(7.5f, 0, 0), transform.rotation);
        yield return new WaitForSeconds(10);

        tutorialText.text = "Over time, the enemy's leader — Galactus — will be reforged. Bombs home in on it and are the only means to damage it. Press Left Shift to deploy a bomb.";
        yield return new WaitForSeconds(10);

        tutorialText.text = "Eventually, asteroids will drop powerup crystals. Pass over it to collect it. It will increase your firing rate immensely.";
        Instantiate(powerup, new Vector3(7.5f, 0, 0), transform.rotation);
        yield return new WaitForSeconds(10);

        tutorialText.text = "That is all you need to know for your mission. Good luck out there, friend. Moving you to the enemy sector.";
        yield return new WaitForSeconds(10);

        ScoreManager.score = 0;
        SceneManager.LoadScene("Level 1");
    }
}
