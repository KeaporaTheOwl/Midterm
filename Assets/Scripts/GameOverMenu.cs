using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void RestartGame()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
