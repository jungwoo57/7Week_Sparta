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
    public const int stageCount = 3;
    public List<StageData> stageDataList = new List<StageData>();
    public int curStageId;

    //Player player;

    private void Start()
    {
        NewStageData();
    }

    public void NewStageData()
    {
        // stageCount 갯수의 stages List를 생성. id는 0,1,2 이고 stageStat는 Locked로 초기화
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
    private void LoadStage(int stageId)
    {
        curStageId = stageId;

        SceneManager.LoadScene($"Stage{curStageId}");
    }

    public void Restart()
    {
        LoadStage(curStageId);
    }

    public void ClearStage()
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

        // 다음 스테이지가 존재하면 Open 상태로 변경
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

        // 변경된 데이터 저장
        SaveStageData();

        // 현재 스테이지 다시 로드 (재시작)
        LoadStage(curStageId);
    }
}
