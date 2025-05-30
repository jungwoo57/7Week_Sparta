using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform titleTransform;
    private Vector2 titleOriginalPos;
    
    [SerializeField]
    private RectTransform restartBtnTransform;
    private Vector2 restartBtnPos;
    private CanvasGroup restartBtnCanvasGroup;
    
    [SerializeField]
    private RectTransform nextStageBtnTransform;
    private Vector2 nextStageBtnPos;
    private CanvasGroup nextStageBtnCanvasGroup;
    
    [SerializeField]
    private RectTransform quitBtnTransform;
    private Vector2 quitBtnPos;
    private CanvasGroup quitBtnCanvasGroup;
    
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
        
        quitBtnCanvasGroup = quitBtnTransform.gameObject.GetComponent<CanvasGroup>();
        restartBtnCanvasGroup = restartBtnTransform.gameObject.GetComponent<CanvasGroup>();
        nextStageBtnCanvasGroup = nextStageBtnTransform.gameObject.GetComponent<CanvasGroup>();
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
        SetClearTimeText(Stage.Instance.ElapsedTime);
        SetBombCountText(Stage.Instance.usedBombCount);
        
        AnimateUI();
        
        
    }

    private void AnimateUI()
    {
        // GameOver 타이틀 텍스트 애니메이션
        titleTransform.anchoredPosition = titleOriginalPos + new Vector2(0,100);
        titleTransform.DOAnchorPos(titleOriginalPos, 0.6f).SetEase(Ease.OutQuad);
        
        restartBtnTransform.anchoredPosition = restartBtnPos - new Vector2(0,50);
        nextStageBtnTransform.anchoredPosition = nextStageBtnPos - new Vector2(0,50);
        quitBtnTransform.anchoredPosition = quitBtnPos - new Vector2(0,50);
        
        restartBtnCanvasGroup.alpha = 0;
        nextStageBtnCanvasGroup.alpha = 0;
        quitBtnCanvasGroup.alpha = 0;

        restartBtnCanvasGroup.DOFade(1f, 0.6f).SetDelay(0.5f);
        nextStageBtnCanvasGroup.DOFade(1f, 0.6f).SetDelay(0.8f);
        quitBtnCanvasGroup.DOFade(1f, 0.6f).SetDelay(1f);
        
        restartBtnTransform.DOAnchorPos(restartBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(0.5f);
        nextStageBtnTransform.DOAnchorPos(nextStageBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(0.8f);
        quitBtnTransform.DOAnchorPos(quitBtnPos, 0.6f).SetEase(Ease.OutQuad).SetDelay(1f);
    }

    public void SetClearTimeText(float elapsedTime)
    {
        int totalSeconds = (int)elapsedTime;
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
        StartCoroutine(NextStage());
        
    }

    IEnumerator NextStage()
    {
        Stage.Instance.uiManager.FadeOut();
        yield return new WaitForSeconds(1);
        stageManager.NextStage();
    }

    

    public void OnDisable()
    {
        DOTween.Kill(titleTransform);
        DOTween.Kill(restartBtnTransform);
        DOTween.Kill(nextStageBtnTransform);
        DOTween.Kill(quitBtnTransform);
    }
}