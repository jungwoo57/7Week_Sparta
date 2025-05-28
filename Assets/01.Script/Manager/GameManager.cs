using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public const int AllStageCount = 15;

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
    public SaveLoadManager SaveLoadManager { get; private set; }
    public StageManager StageManager { get; private set; }
    public PlayerManager PlayerManager { get; private set; }
    
    private void Awake()
    {
        Singleton();
        InitManagers();
    }

    // Manager들 초기화 및 DonDestroyOnLoad 처리
    private void InitManagers()
    {
        SaveLoadManager = FindObjectOfType<SaveLoadManager>();
        if (SaveLoadManager == null)
        {
            SaveLoadManager = new GameObject("SaveLoadManager").AddComponent<SaveLoadManager>();
            DontDestroyOnLoad(SaveLoadManager);
        }

        StageManager = FindObjectOfType<StageManager>();
        if (StageManager == null)
        {
            StageManager = new GameObject("StageManager").AddComponent<StageManager>();
            DontDestroyOnLoad(StageManager);
        }

        PlayerManager = FindObjectOfType<PlayerManager>();
        if (PlayerManager == null)
        {
            PlayerManager = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            DontDestroyOnLoad(PlayerManager);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
