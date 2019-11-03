using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private int asteroidPoints = 5;
    private int crystalPoints = 200;
    private int enemyPoints = 500;
    private int bossDamagePoints = 500;
    private int bossDestructionPoints = 15000;
    [SerializeField] private Text playerScore;

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + score;
    }

    public void AsteroidScoring()
    {
        score = score + asteroidPoints;
    }

    public void CrystalScoring()
    {
        score = score + crystalPoints;
    }

    public void EnemyScoring()
    {
        score = score + enemyPoints;
    }

    public void BossDamageScoring()
    {
        score = score + bossDamagePoints;
    }

    public void BossDestructionScoring()
    {
        score = score + bossDestructionPoints;
    }
}