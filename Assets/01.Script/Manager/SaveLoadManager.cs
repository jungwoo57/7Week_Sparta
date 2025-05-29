using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveDataWrapper
{
    public List<StageData> dataList;

    public SaveDataWrapper(List<StageData> list)
    {
        dataList = list;
    }
}

public class SaveLoadManager : MonoBehaviour
{
    private string path;
    public List<StageData> saveDataList = new();

    private void Awake()
    {
        path = Application.persistentDataPath + "/save.json";
    }

    public void SaveData(List<StageData> stageDataList)
    {
        saveDataList?.Clear();

        foreach (StageData stageData in stageDataList)
        {
            saveDataList.Add(stageData);
        }

        try
        {
            string json = JsonUtility.ToJson(new SaveDataWrapper(saveDataList));
            File.WriteAllText(path, json);
            Debug.Log("Save Success");
        }
        catch (IOException e)
        {
            Debug.LogError($"Save Failed: {e.Message}");
        }
    }

    public List<StageData> LoadData(List<StageData> stageDataList)
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found.");
            return stageDataList;
        }

        try
        {
            string json = File.ReadAllText(path);
            SaveDataWrapper wrapper = JsonUtility.FromJson<SaveDataWrapper>(json);

            if (wrapper != null && wrapper.dataList != null)
            {
                if (wrapper.dataList.Count != StageManager.stageCount)
                {
                    Debug.LogError("DataBroken: save data count mismatch.");
                    return stageDataList;
                }

                saveDataList = new List<StageData>(wrapper.dataList);
                stageDataList = new List<StageData>(saveDataList);
            }
            else
            {
                Debug.LogWarning("Loaded data is null or empty.");
            }
        }
        catch (IOException e)
        {
            Debug.LogError($"Load Failed: {e.Message}");
        }

        return stageDataList;
    }
}
