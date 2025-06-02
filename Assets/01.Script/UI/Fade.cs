using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    public void FadeIn()
    {
        Color targetColor = image.color;
        targetColor.a = 0;
        image.DOColor(targetColor, 1f);
    }
    public void FadeOut()
    {
        Color targetColor = image.color;
        targetColor.a = 1;
        image.DOColor(targetColor, 1f);
    }
    
}
