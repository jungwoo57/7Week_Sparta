using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string path;
    public Stage stageData = new Stage();


    private void Awake()
    {
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
            stageData = JsonUtility.FromJson<Stage>(data);
        }
        catch (IOException e)
        {
            Debug.LogError($"Load Failed: {e.Message}");
        }
    }
}
