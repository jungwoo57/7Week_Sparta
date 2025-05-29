using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageState
{
    Locked,
    Open,
    Cleared
}

[Serializable]
public struct StageData
{
    public int id;
    public StageState stageState;
}

public class StageManager : MonoBehaviour
{

    public UIManager uiManager;
    public int usedBombCount;

    public const int stageCount = 3;
    public List<StageData> stageDataList = new List<StageData>();
    public int curStageId;

    //Player player;

    public float ElapsedTime { get; private set; }
    public bool IsCleared { get; private set; }

    private void Awake()
    {
        IsCleared = false;
    }


    private void Start()
    {
        NewStageData();
    }

    private void Update()
    {
        if (!IsCleared)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    public void InitStage()
    {
        usedBombCount = 0;
        ElapsedTime = 0;
        IsCleared = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    public void ClearStage()
    {
        IsCleared = true;
        Cursor.lockState = CursorLockMode.None;
        
        // TODO : 클리어 시간과 사용 폭탄 수 uiManager에 셋팅
        // ShowGameClearPanel에 파라미터를 추가하거나 해도 좋을 것 같습니다
        // 사용 폭탄 갯수 플레이어 말고 스테이지 매니저가 들고 있는 것도 좋을 것 같아요
        // 경과 시간은 Update에도 적혀있는 ElapsedTime 참고
        
        uiManager.ShowGameClearPanel();
    }
    public void NewStageData()
    {
        stageDataList.Clear();


        for (int i = 0; i < stageCount; i++)
        {
            StageState state = (i == 0) ? StageState.Open : StageState.Locked;

            StageData stageData = new StageData
            {
                id = i,
                stageState = state
            };
            stageDataList.Add(stageData);
        }
    }

    public void SaveStageData()
    {
        GameManager.Instance.SaveLoadManager.SaveData(stageDataList);
    }

    public void LoadStageData()
    {
        stageDataList = GameManager.Instance.SaveLoadManager.LoadData(stageDataList);
    }

    // StageManager에서만 사용하는 메서드. stageId로 씬을 불러오는 메서드.
    public void LoadStage(int stageId)
    {
        curStageId = stageId;

        SceneManager.LoadScene($"Stage{curStageId}");
    }

    public void Restart()
    {
        LoadStage(curStageId);
    }

    public void NextStage()
    {
        // 현재 스테이지의 State를 Cleared로 변경하고, 
        for (int i = 0; i < stageDataList.Count; i++)
        {
            if (stageDataList[i].id == curStageId)
            {
                StageData updatedData = stageDataList[i];
                updatedData.stageState = StageState.Cleared;
                stageDataList[i] = updatedData;
                break;
            }
        }
        int nextStageId = curStageId + 1;
        if (nextStageId < stageDataList.Count)
        {
            for (int i = 0; i < stageDataList.Count; i++)
            {
                if (stageDataList[i].id == nextStageId)
                {
                    StageData updatedData = stageDataList[i];
                    updatedData.stageState = StageState.Open;
                    stageDataList[i] = updatedData;
                    break;
                }
            }
        }
        else
        {
            Debug.Log("마지막 스테이지입니다.");
        }
        SaveStageData();
        
    }

    
}
