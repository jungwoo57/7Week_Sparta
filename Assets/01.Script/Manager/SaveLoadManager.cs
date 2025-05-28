using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public struct SaveData
{
    public int id;
    public StageState stageState;
}

[Serializable]
public class SaveDataWrapper
{
    public List<SaveData> dataList;

    public SaveDataWrapper(List<SaveData> list)
    {
        dataList = list;
    }
}

public class SaveLoadManager : MonoBehaviour
{
    private string path;
    public List<SaveData> saveDataList = new();

    private void Awake()
    {
        path = Application.persistentDataPath + "/save.json";
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData(List<Stage> stages)
    {
        if (saveDataList != null)
        {
            saveDataList.Clear();
        }

        foreach (Stage stage in stages)
        {
            saveDataList.Add(stage.ToSaveData());
        }

        try
        {
            string json = JsonUtility.ToJson(new SaveDataWrapper(saveDataList));
            File.WriteAllText(path, json);
        }
        catch (IOException e)
        {
            Debug.LogError($"Save Failed: {e.Message}");
        }
    }

    public List<SaveData> LoadData()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found.");
            return new List<SaveData>();
        }

        try
        {
            string json = File.ReadAllText(path);
            SaveDataWrapper wrapper = JsonUtility.FromJson<SaveDataWrapper>(json);
            saveDataList = wrapper.dataList;
            return saveDataList;
        }
        catch (IOException e)
        {
            Debug.LogError($"Load Failed: {e.Message}");
            return new List<SaveData>();
        }
    }
}
