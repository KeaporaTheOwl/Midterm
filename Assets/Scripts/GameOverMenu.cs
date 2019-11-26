using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private int finalScore;
    [SerializeField] private Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreManager.score;
        finalScoreText.text = "You scored: " + finalScore + " points!";
        ScoreManager.score = 0;
        PlayerController.playerLives = 3;
        PlayerController.crystalsCollected = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}