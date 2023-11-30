using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager instance;

    [SerializeField] private GameObject ballObject, fontImg;
    private bool isScale;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        

    }

    private void Start()
    {
            ballObject.transform.DOScale(1, 1).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.OutSine);
        InvokeRepeating("SetDelay", 1f, 3000f);

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    private void SetDelay()
    {
        fontImg.transform.DOScale(1.3f, 1).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.OutSine);

    }


    public void GetOverUI()
    {
        
    }




}







