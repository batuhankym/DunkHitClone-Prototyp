using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;

  
   public void IncreaseScore(int score)
   {
      scoreText.text = score.ToString();

      scoreText.transform.DOScale(1.3f, 0.3f);



   }

   public void ReturnOriginalScale()
   {
      scoreText.transform.DOScale(1f, 0.5f);


   }
   
   
}
