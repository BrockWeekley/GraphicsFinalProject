using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public Transform pin;
    public float threshold = .9f;
    public int point = 1;
    public Score scoreBoard;

    Vector3 startPosition;
    Quaternion startRotation;

    void Awake()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();      
    }

    void Start()
    {
        startPosition = pin.position;
        startRotation = pin.rotation;
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

    public void ResetPin()
    {
        pin.position = startPosition;
        pin.rotation = startRotation;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    void Update()
    {
        CheckIfFell();
    }
}
