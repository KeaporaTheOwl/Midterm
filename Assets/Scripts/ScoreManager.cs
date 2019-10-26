using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text playerScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + score;
    }

    public void AsteroidScoring()
    {
        score = score + 5;
    }

    public void CrystalScoring()
    {
        score = score + 200;
    }

    public void EnemyScoring()
    {
        score = score + 500;
    }

    public void BossDamageScoring()
    {
        score = score + 500;
    }

    public void BossDestructionScoring()
    {
        score = score + 15000;
    }
}
