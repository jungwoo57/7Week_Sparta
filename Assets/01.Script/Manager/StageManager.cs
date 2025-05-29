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
        SetStageProto();
    }

    private void SetStageProto()
    {
        for (int i = 0; i < GameManager.AllStageCount; i++)
        {
            Stage stage = new Stage();
            stage.SetIdForProto(i);
            stages.Add(stage);
        }

        Debug.Log("프로토 스테이지 셋팅 완료");
    }

    private void Start()
    {
        //SetStages();
        //GameManager.Instance.SaveLoadManager.SaveData(stages);
        //UpdateStageStates();
    }

    public void InitStage(int stageId)
    {
        curStage = stages.Find(stage => stage.Id == stageId);
        if (curStage == null)
        {
            Debug.Log("스테이지를 찾을 수 없음 || " + stages[0].Id + " || " + stageId);
            Debug.Log(stages[0].Id == stageId);
        }

        usedBombCount = 0;
        ElapsedTime = 0;
        IsCleared = false;
        Cursor.lockState = CursorLockMode.Locked;
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


        // TODO : 클리어 시간과 사용 폭탄 수 uiManager에 셋팅
        // ShowGameClearPanel에 파라미터를 추가하거나 해도 좋을 것 같습니다
        // 사용 폭탄 갯수 플레이어 말고 스테이지 매니저가 들고 있는 것도 좋을 것 같아요
        // 경과 시간은 Update에도 적혀있는 ElapsedTime 참고

        // stages[curStage.Id].SetState(StageState.Cleared);
        // stages[curStage.Id + 1].SetState(StageState.Open);
        // GameManager.Instance.SaveLoadManager.SaveData(stages);
        uiManager.ShowGameClearPanel();
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