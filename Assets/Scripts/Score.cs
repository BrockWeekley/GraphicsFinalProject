using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreBoard;

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScoreBoard();
    }

    void Start()
    {
        score = 0;
    }

    void UpdateScoreBoard()
    {
        scoreBoard.text = "Score: " + score;
    }
   
}
