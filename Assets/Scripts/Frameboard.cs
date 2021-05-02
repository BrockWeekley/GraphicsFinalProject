using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frameboard : MonoBehaviour
{
    public int frame = 0;
    public Text frameBoard;

    public void AddFrame()
    {
        frame++;
        UpdateFrameBoard();
    }

    void Start()
    {
        frame = 1;
    }

    void UpdateFrameBoard()
    {
        frameBoard.text = "Frame: " + frame;
    }
}
