using System.IO;
using UnityEngine;

public class StageData
{
    public int stageIndex;
}

public class SaveLoadManager : MonoBehaviour
{
    #region Singleton
    private static SaveLoadManager _instance;
    public static SaveLoadManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("SaveLoadManager").AddComponent<SaveLoadManager>();
            }
            return _instance;
        }
    }

    private void Singleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    public StageData stageData = new StageData();
    private string path;

    private void Awake()
    {
        Singleton();
        path = Application.persistentDataPath + "/save";
    }

    public void SaveData()
    {
        try
        {
            string data = JsonUtility.ToJson(stageData);
            File.WriteAllText(path, data);
        }
        catch (IOException e)
        {
            Debug.LogError($"Save Failed: {e.Message}");
        }
    }

    public void LoadData()
    {
        try
        {
            string data = File.ReadAllText(path);
            stageData = JsonUtility.FromJson<StageData>(data);
        }
        catch (IOException e)
        {
            Debug.LogError($"Load Failed: {e.Message}");
        }
    }
}
