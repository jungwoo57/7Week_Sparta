using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage curStage;
    public List<Stage> stages = new List<Stage>();
    public UIManager uiManager;
    public int usedBombCount;
    //Player player;

    public float ElapsedTime { get; private set; }
    public bool IsCleared { get; private set; }

    private void Awake()
    {
        IsCleared = false;
    }

    private void Start()
    {
        Init();
        //SetStages();
        //GameManager.Instance.SaveLoadManager.SaveData(stages);
        //UpdateStageStates();
    }

    public void Init()
    {
        usedBombCount = 0;
        ElapsedTime = 0;
        IsCleared = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiManager.gameClearPanel.SetActive(false);
    }

    private void Update()
    {
        if (!IsCleared)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    public void ClearStage()
    {
        IsCleared = true;
        Cursor.lockState = CursorLockMode.None;
        GameManager.Instance.StageManager.uiManager.ShowGameClearPanel();
    }

    private void SetStages()
    {
        GameObject stageParent = GameObject.Find("Stage");
        if (stageParent == null)
        {
            Debug.LogError("Stage is missing!");
            return;
        }

        for (int i = 0; i < stageParent.transform.childCount; i++)
        {
            Transform child = stageParent.transform.GetChild(i);
            Stage stageComponent = child.GetComponent<Stage>();

            if (stageComponent != null)
            {
                //stages.Add(stageComponent);
            }
            else
            {
                Debug.LogError("Stage component is missing!");
            }
        }
    }

    public void UpdateStageStates()
    {
        var loadedList = GameManager.Instance.SaveLoadManager.saveDataList;

        foreach (var data in loadedList)
        {
            //Stage stage = stages.Find(s => s.Id == data.id);
            //if (stage != null)
            //{
            //    stage.LoadFromSaveData(data);
            //}
            // else
            // {
            //     Debug.LogWarning($"ID {data.id}에 해당하는 Stage를 찾을 수 없습니다.");
            // }
        }
    }

    public void LoadStage(int stageId)
    {
        // ReStart 버튼으로 스테이지 정보 초기화
        //curStage = stages[stageId];

        //player.transform = curStage.PlayerStartPosition;
        // camera.transform = _curStage.CameraStartPosition;
    }

    
    private void ClearStageLegacy()
    {
        // 현재 스테이지의 State를 Cleared로 바꾸고, 다음 스테이지를 Open한다.
        //stages[curStage.Id].SetState(StageState.Cleared);
        //stages[curStage.Id + 1].SetState(StageState.Open);

        // 다음 스테이지를 로드
        LoadStage(curStage.Id + 1);
    }
}
