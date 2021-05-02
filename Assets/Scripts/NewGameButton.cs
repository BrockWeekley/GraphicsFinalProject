using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = .025f;
    public UnityEvent onPressed, onReleased;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    public Score scoreBoard;
    public Frameboard frameBoard;
    public Totalboard totalBoard;

    public GameObject[] pins;
    public GameObject bowlingBall;

    Vector3 ballStartPosition;
    Quaternion ballStartRotation;

    void Awake()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();
        frameBoard = GameObject.FindGameObjectWithTag("Frame").GetComponent<Frameboard>();
        totalBoard = GameObject.FindGameObjectWithTag("Total").GetComponent<Totalboard>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        bowlingBall = GameObject.FindGameObjectWithTag("BowlingBall");
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

        ballStartPosition = bowlingBall.transform.position;
        ballStartRotation = bowlingBall.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (isPressed && GetValue() - threshold <= 0)
            Released();

    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void GameRoundReset()
    {
        BowlingPin currentPin;

        //increment total with current score, then clear score
        totalBoard.AddTotal(scoreBoard.score);
        scoreBoard.ClearScore();

        //reest each pin
        foreach(GameObject pin in pins)
        {
            currentPin = pin.GetComponent<BowlingPin>();
            //currentPin.ResetPin();
        }

        //reset bowlingball position
        bowlingBall.transform.position = ballStartPosition;
        bowlingBall.transform.rotation = ballStartRotation;

        //increment frame
        frameBoard.AddFrame();
        //if we have reached 10 frames, just reset the game
        if(frameBoard.frame == 10)
        {
            SceneManager.LoadScene("VR Bowling");
        }
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        isPressed = false;
        //SceneManager.LoadScene("VR Bowling");
        GameRoundReset();
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
