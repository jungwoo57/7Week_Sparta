﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
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

    private List<AssetReferenceGameObject> stagePrefabs;
    public List<StageData> stageDataList = new List<StageData>();
    public int curStageId;

    private AsyncOperationHandle<SceneInstance> stageSceneHandle;

    private void Start()
    {
        NewStageData();
    }

    public void NewStageData()
    {
        stageDataList.Clear();

        for (int i = 0; i < stageCount; i++)
        {
            StageState state = StageState.Open;

            StageData stageData = new StageData
            {
                id = i,
                stageState = state
            };
            stageDataList.Add(stageData);
        }
    }

    public void SaveStageClearedData()
    {
        // 현재 스테이지의 State를 Cleared로 변경하고, 
        for (int i = 0; i < stageDataList.Count; i++)
        {
            if (stageDataList[i].id == curStageId-1)
            {
                StageData updatedData = stageDataList[i];
                updatedData.stageState = StageState.Cleared;
                stageDataList[i] = updatedData;
                break;
            }
        }
        int nextStageId = curStageId;
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
        
        GameManager.Instance.SaveLoadManager.SaveData(stageDataList);
    }
    

    // StageManager에서만 사용하는 메서드. stageId로 씬을 불러오는 메서드.
    public void LoadStage(int stageId)
    {
        curStageId = stageId;
        stageSceneHandle = Addressables.LoadSceneAsync($"Stage{stageId}");  // 로드씬 모드 싱글
    }

    public void Restart()
    {
        LoadStage(curStageId);
    }

    public void NextStage()
    {
        LoadStage(curStageId + 1);
    }    
}
