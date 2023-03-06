using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Screen = UnityEngine.Device.Screen;

public class BallController : MonoBehaviour
{

    //Components
    private Rigidbody _ballRb;
    private float repeatWith;

    //Classes
    private GameObject _hoopManager;
    public HoopManager hoopManager;
    public GameObject pointManager;
    public ScoreManager scoreManager;
    public CountdownManager countDownManager;

    //Variables
    [SerializeField] private float ballJumpForce;
    [SerializeField] private float ballMoveForce;
    [SerializeField] private Vector3 ballScreenPos;
    private Vector2 _screenBound;
    private int _score = 1;

    //Booleans
    private bool _isMouseClicked;
    private bool _isBallScoreInNest;

    //References
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform ballTrans;

    [SerializeField] private float screenBorder = 10;
    private float objectWidth;
    private float objectHeight;



    private void Start()
    {



        ballScreenPos = transform.position;
        countDownManager.GetComponent<CountdownManager>();
        scoreManager.GetComponent<ScoreManager>();
        _hoopManager = GameObject.FindGameObjectWithTag("Hoop");
        hoopManager.GetComponent<HoopManager>();


        _ballRb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        var objPosition = transform.position;
        var cameraPosition = mainCam.transform.position;
        var cameraViewSize = mainCam.orthographicSize;
        var cameraAspectRatio = mainCam.aspect;

        var xMin = cameraPosition.x - cameraViewSize * cameraAspectRatio;
        var xMax = cameraPosition.x + cameraViewSize * cameraAspectRatio;

        if (objPosition.x < xMin)
        {
            objPosition.x = xMax;
            _ballRb.AddForce(Vector3.left * 40);

            _ballRb.velocity = Vector3.zero;



        }
        else if (objPosition.x > xMax)
        {
            objPosition.x = xMin;
            _ballRb.AddForce(Vector3.right * 40);

            _ballRb.velocity = Vector3.zero;



        }

        transform.position = objPosition;
    }

    private void Update()
    {






        if (Input.GetMouseButtonDown(0))
        {
            _isMouseClicked = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseClicked = false;
        }




    }

    private void FixedUpdate()
    {
        if (_isMouseClicked && _isBallScoreInNest)
        {
            ForceBallJumpLeft();

        }

        if (_isMouseClicked && !_isBallScoreInNest)
        {
            ForceBallJumpRight();
        }
    }

    private void ForceBallJumpLeft()
    {
        _ballRb.AddForce((Vector3.up * (ballJumpForce * Time.deltaTime)));
        _ballRb.AddForce((Vector3.left * (ballMoveForce * Time.deltaTime)));


    }

    private void ForceBallJumpRight()
    {
        _ballRb.AddForce((Vector3.up * (ballJumpForce * Time.deltaTime)));
        _ballRb.AddForce((Vector3.right * (ballMoveForce * Time.deltaTime)));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreColLeft"))
        {
            countDownManager.isBallHit = true;
            _isBallScoreInNest = false;
            hoopManager.MoveLeftHoop();
            pointManager.SetActive(true);
            scoreManager.IncreaseScore(_score);
            _score++;
            scoreManager.Invoke(nameof(ScoreManager.ReturnOriginalScale), 1.1f);

        }

        if (other.gameObject.CompareTag("ScoreColRight"))
        {
            countDownManager.isBallHit = true;

            _isBallScoreInNest = true;
            hoopManager.MoveRightHoop();
            pointManager.SetActive(true);
            scoreManager.IncreaseScore(_score);
            _score++;
            scoreManager.Invoke(nameof(ScoreManager.ReturnOriginalScale), 1.1f);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        countDownManager.isBallHit = false;

    }
}
