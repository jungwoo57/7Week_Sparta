using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage curStage;
    public List<Stage> stages = new List<Stage>();

    //Player player;

    private void Start()
    {

        SetStages();
        //UpdateStageStates();
        GameManager.Instance.SaveLoadManager.SaveData();
    }

    private void Update()
    {
        CheckClearCondition();
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
                stages.Add(stageComponent);
            }
            else
            {
                Debug.LogError("Stage component is missing!");
            }
        }
    }

    public void UpdateStageStates()
    {
        for (int i = 0; i < stages.Count; i++)
        {
            stages[i].StageState = GameManager.Instance.SaveLoadManager.stageDataList[i].stageState;
        }
    }

    public void LoadStage(int stageId)
    {
        // ReStart 버튼으로 스테이지 정보 초기화
        curStage = stages[stageId];

        //player.transform = curStage.PlayerStartPosition;
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
        stages[curStage.Id].SetState(StageState.Cleared);
        stages[curStage.Id + 1].SetState(StageState.Open);

        // 다음 스테이지를 로드
        LoadStage(curStage.Id + 1);
    }
}
