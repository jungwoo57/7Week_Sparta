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
    public int curStageIndex;

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

    public void LoadStage(int stageId)
    {
        // ReStart 버튼으로 스테이지 정보 초기화
        curStageIndex = stageId;

        SceneManager.LoadScene($"Stage{curStageIndex}");

        // player.transform = curStage.PlayerStartPosition;
        // camera.transform = _curStage.CameraStartPosition;
    }

    private void CheckClearCondition()
    {
        // 플레이어의 위치 체크
        // 만약 플레이어의 위치가 curStage.Destination과 일정 거리 사이라면
        // ClaerStage() 호출
    }

    private void ClearStage()
    {
        // 현재 스테이지의 State를 Cleared로 바꾸고, 다음 스테이지를 Open한다.
        //stages[curStage.Id].SetState(StageState.Cleared);
        //stages[curStage.Id + 1].SetState(StageState.Open);

        // 다음 스테이지를 로드
        //LoadStage(curStage.Id + 1);
    }
}
