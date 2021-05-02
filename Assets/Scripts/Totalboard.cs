using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totalboard : MonoBehaviour
{
    public int totalScore = 0;
    public Text totalBoard;

    public void AddTotal(int newScore)
    {
        totalScore += newScore;
        UpdateTotalBoard();
    }

    void Start()
    {
        totalScore = 0;
    }

    void UpdateTotalBoard()
    {
        totalBoard.text = "Total: " + totalScore;
    }
}
