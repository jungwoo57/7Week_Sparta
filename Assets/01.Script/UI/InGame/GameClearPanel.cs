using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform titleTransform;
    private Vector2 titleOriginalPos;
    
    [SerializeField]
    private RectTransform restartBtnTransform;
    private Vector2 restartBtnPos;
    
    [SerializeField]
    private RectTransform nextStageBtnTransform;
    private Vector2 nextStageBtnPos;
    
    [SerializeField]
    private RectTransform quitBtnTransform;
    private Vector2 quitBtnPos;
    
    [SerializeField]
    TextMeshProUGUI clearTimeText;
    [SerializeField]
    TextMeshProUGUI usedBombText;

    StageManager stageManager;

    private void Awake()
    {
        // UI 요소들 원위치 저장
        titleOriginalPos = titleTransform.anchoredPosition;
        restartBtnPos = restartBtnTransform.anchoredPosition;
        nextStageBtnPos = nextStageBtnTransform.anchoredPosition;
        quitBtnPos = quitBtnTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        if (!stageManager)
        {
            stageManager = GameManager.Instance.StageManager;
        }

        if (stageManager.curStageId == StageManager.stageCount)
        {
            nextStageBtnTransform.GetComponent<Button>().interactable = false;
            nextStageBtnTransform.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, 120);
        }
        AnimateUI();
        
        // SetClearTimeText(stageManager.ElapsedTime);
        SetBombCountText(0);
    }

    private void AnimateUI()
    {
        // GameOver 타이틀 텍스트 애니메이션
        titleTransform.anchoredPosition = titleOriginalPos + new Vector2(0,100);
        titleTransform.DOAnchorPos(titleOriginalPos, 0.6f).SetEase(Ease.OutQuad);
        
        restartBtnTransform.anchoredPosition = restartBtnPos - new Vector2(0,50);
        nextStageBtnTransform.anchoredPosition = nextStageBtnPos - new Vector2(0,50);
        quitBtnTransform.anchoredPosition = quitBtnPos - new Vector2(0,50);
        
        restartBtnTransform.DOAnchorPos(restartBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        nextStageBtnTransform.DOAnchorPos(nextStageBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(0.3f);
        quitBtnTransform.DOAnchorPos(quitBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(0.4f);
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
        stageManager.NextStage();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    public void OnDisable()
    {
        DOTween.Kill(titleTransform);
        DOTween.Kill(restartBtnTransform);
        DOTween.Kill(nextStageBtnTransform);
        DOTween.Kill(quitBtnTransform);
    }
}