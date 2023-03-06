using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class HoopManager : MonoBehaviour
{
    public GameObject rightHoop;
    public GameObject lefttHoop;



    public void MoveRightHoop()
    {
        rightHoop.transform.DOMoveX(3.3f, 1f);
        lefttHoop.transform.DOMoveX(-1.37f, 1f);
        Invoke(nameof(ChangeYAxisR), 1f);

    }

    public void MoveLeftHoop()
    {
       rightHoop.transform.DOMoveX(1.37f, 1f);
        lefttHoop.transform.DOMoveX(-2.69f, 1f);
        Invoke(nameof(ChangeYAxisL), 1f);

    }

    public void ChangeYAxisR()
    {
        rightHoop.transform.position = new Vector3(rightHoop.transform.position.x,Random.Range(0,2.2f),rightHoop.transform.position.z);

    }
    
    public void ChangeYAxisL()
    {
        lefttHoop.transform.position = new Vector3(lefttHoop.transform.position.x,Random.Range(0,2.2f),lefttHoop.transform.position.z);

    }

}
