using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PointManager : MonoBehaviour
{
    private Vector3 _currentPos;

    private void Start()
    {
        _currentPos = transform.position;
    }

    private void OnEnable()
    {
        transform.DOMoveY(2050, 1);
        transform.DOScale(1.1f, 1);
        Invoke(nameof(CloseObject),1.1f);

    }

    private void OnDisable()
    {
        transform.position = _currentPos;

    }

    private void CloseObject()
    {
        this.gameObject.SetActive(false);
    }
}
