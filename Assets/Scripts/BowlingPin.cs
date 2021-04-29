using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public Transform pin;
    public float threshold = .6f;
    public int point = 1;
    public Score scoreBoard;

    void Awake()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();
    }

    void CheckIfFell()
    {
        try
        {
            if(pin.up.y < threshold && gameObject.GetComponent<Collider>().enabled == true)
            {
                scoreBoard.AddScore(point);
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
        catch
        {
            Debug.Log("Pin in the out of bounds zone");
        }
    }

    void Update()
    {
        CheckIfFell();
    }
}
