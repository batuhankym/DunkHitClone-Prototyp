using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class CountdownManager : MonoBehaviour
{
    public Slider countdownSlider;
    public float gameTime;
    public bool isBallHit;
    
    // Start is called before the first frame update
    void Start()
    {
        countdownSlider.maxValue = gameTime;
        countdownSlider.value = gameTime;
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
        }

        gameTime -= Time.deltaTime;
        countdownSlider.value = gameTime;
        
    }
}
