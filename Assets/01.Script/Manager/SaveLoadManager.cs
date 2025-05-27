using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public int id;
    public StageState stageState;
}

public class SaveLoadManager : MonoBehaviour
{
    private string path;
    public List<SaveData> stageDataList = new();

    private void Awake()
    {
        path = Application.dataPath + "/save";
    }

    public void SaveData()
    {
        for (int i = 0; i < GameManager.Instance.StageManager.stages.Count; i++)
        {
            stageDataList[i].id = GameManager.Instance.StageManager.stages[i].Id;
            stageDataList[i].stageState = GameManager.Instance.StageManager.stages[i].StageState;
        }

        try
        {
            string json = JsonUtility.ToJson(stageDataList);
            File.WriteAllText(path, json);
        }
        catch (IOException e)
        {
            Debug.LogError($"Save Failed: {e.Message}");
        }
    }

    public List<SaveData> LoadData()
    {
        try
        {
            if (!File.Exists(path))
            {
                Debug.LogWarning("Save file not found.");
                return new List<SaveData>();
            }

            string json = File.ReadAllText(path);
            List<SaveData> dataList = JsonUtility.FromJson<List<SaveData>>(json);
            return dataList;
        }
        catch (IOException e)
        {
            Debug.LogError($"Load Failed: {e.Message}");
            return new List<SaveData>();
        }
    }
}
