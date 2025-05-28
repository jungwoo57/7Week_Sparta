using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clearTimeText;
    [SerializeField] TextMeshProUGUI usedBombText;

    private void Start()
    {
        // 테스트
        SetClearTimeText(1529431);
        SetBombCountText(6);
    }

    public void SetClearTimeText(float elapsedTime)
    {
        int totalSeconds = Mathf.FloorToInt(elapsedTime / 1000f);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        clearTimeText.text = $"{minutes:D2}:{seconds:D2}";
    }

    public void SetBombCountText(int count)
    {
        usedBombText.text = count + " 개";
    }
        
    public void OnClickNextStage()
    {
        
    }
}
