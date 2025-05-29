using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        AnimateUI();
        
        SetClearTimeText(stageManager.ElapsedTime);
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
        nextStageBtnTransform.DOAnchorPos(nextStageBtnPos, 0.6f).SetEase(Ease.OutQuad);
        quitBtnTransform.DOAnchorPos(quitBtnPos, 0.6f).SetEase(Ease.OutQuad);
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
        Debug.Log("스테이지 ID 기반 작동입니다. 기능이 완료되면 나중에 로그 지워주세요");

        int curStageId = stageManager.curStage.Id;
        SceneManager.LoadScene($"Stage{curStageId + 1}");
        stageManager.InitStage(curStageId + 1);
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        stageManager.InitStage(stageManager.curStage.Id);
    }
}