using UnityEngine;

public class Stage : MonoBehaviour
{
    public static Stage Instance { get; private set; }


    [Header("MapData")]
    [SerializeField] private int bombCount; // maxbombCount로 변경
    public int usedBombCount; // 현재 폭탄 갯수로 변경
    [SerializeField] private Vector3 destination;
    public Vector3 Destination => destination;

    public UIManager uiManager;
    private Player player;

    public float ElapsedTime { get; private set; }
    public bool IsCleared { get; private set; }
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }

    private void Start()
    {
        player = GetComponent<Player>();

        InitStage();
    }

    private void Update()
    {
        if (!IsCleared)
        {
            ElapsedTime += Time.deltaTime;
            
        }
    }

    public void InitStage()
    {
        usedBombCount = 0;
        ElapsedTime = 0;
        IsCleared = false;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiManager.playerUI.UIUpdate();
    }

    [ContextMenu("Clear Stage")]
    public void ClearStage()
    {
        IsCleared = true;
        Cursor.lockState = CursorLockMode.None;
        
        // TODO : 클리어 시간과 사용 폭탄 수 uiManager에 셋팅
        // ShowGameClearPanel에 파라미터를 추가하거나 해도 좋을 것 같습니다
        // 사용 폭탄 갯수 플레이어 말고 스테이지 매니저가 들고 있는 것도 좋을 것 같아요
        // 경과 시간은 Update에도 적혀있는 ElapsedTime 참고
        GameManager.Instance.StageManager.SaveStageClearedData();
       
        uiManager.ShowGameClearPanel();
    }

    
    public void PauseStage()
    {
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        uiManager.ShowPausedPanel();
    }
    public void ResumeStage()
    {
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        uiManager.HidePausedPanel();
    }
}
