using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;
using DG.Tweening;
using UnityEngine.Serialization;

public class CountdownManager : MonoBehaviour
{
    [FormerlySerializedAs("overUI")] [SerializeField] GameObject hitUI;
    [FormerlySerializedAs("overUI2")] [SerializeField] GameObject dunkUI;


    
    public Slider countdownSlider;
    public float gameTime;
    public bool isBallHit;

    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject ball, platform, platform2;

    // Start is called before the first frame update
    void Start()
    {
        countdownSlider.maxValue = gameTime;
        countdownSlider.value = gameTime;
        hitUI.transform.DOScale(3f, 1).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.OutSine);
        dunkUI.transform.DOScale(3f, 1).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.OutSine);

    }

    // Update is called once per frame
    void Update()
    {
        if (isBallHit)
        {
            gameTime = 10;
            
        }

        if (gameTime <= 0)
        {
            Debug.Log("GameOver");
            loseUI.SetActive(true);
            gameUI.SetActive(false);
            ball.SetActive(false);
            platform.SetActive(false);
            platform2.SetActive(false);

        }

        gameTime -= Time.deltaTime;
        countdownSlider.value = gameTime;
        
    }

 

}
