using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject titlePanel;

    [SerializeField]
    private GameObject contentBox;

    [SerializeField]
    private GameObject stageSelectButtonPrefab;

    [Header("Page Buttons")]
    [SerializeField]
    private TextMeshProUGUI pageText;
    [SerializeField]
    private Button pageLeftButton;
    [SerializeField]
    private Button pageRightButton;

    private int allStageCount;
    private int pageCount;
    private int currentPage;
    private const int MaxStageCountPerPage = 12;

    StageManager stageManager;
    SaveLoadManager saveLoadManager;
    public void Start()
    {
        ClearContentBox();

        stageManager = GameManager.Instance.StageManager;
        saveLoadManager = GameManager.Instance.SaveLoadManager;
        allStageCount = StageManager.stageCount;
        pageCount = allStageCount / MaxStageCountPerPage + 1;

        ShowTargetPage(1);
    }

    private void ClearContentBox()
    {
        foreach (Transform child in contentBox.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void ShowTargetPage(int pageNumber)
    {
        if (allStageCount == 0)
        {
            Debug.LogError("스테이지 데이터를 찾을 수 없습니다.");
            return;
        }

        currentPage = pageNumber;
        pageText.text = pageNumber + "/" + pageCount;
        ClearContentBox();

        // 페이지에 출력할 스테이지 버튼 수
        int requiredButtonCount;
        if (currentPage == pageCount) requiredButtonCount = allStageCount % MaxStageCountPerPage;
        else requiredButtonCount = 12;

        int startIndex = (pageNumber - 1) * 12;
        for (int i = startIndex; i < startIndex + requiredButtonCount; i++)
        {
            StageData stage = stageManager.stageDataList[i];
            StageSelectButton button = Instantiate(stageSelectButtonPrefab, contentBox.transform)
                .GetComponent<StageSelectButton>();
            button.Init(stage);

            //button.Init(i);
            // 렌더링 리프레시 (안 열린 스테이지 찰나 활성화된 상태로 보이는 것  방지)
            button.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
        }
    }

    public void OnClickBackButton()
    {
        titlePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnClickLeftPage()
    {
        if (currentPage == 1) return;
        currentPage--;
        ShowTargetPage(currentPage);
    }

    public void OnClickRightPage()
    {
        if (currentPage == pageCount) return;
        currentPage++;
        ShowTargetPage(currentPage);
    }
}