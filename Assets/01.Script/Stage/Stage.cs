using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("MapData")]
    [SerializeField] private int _bombCount;
    [SerializeField] private int usedBombCount;
    [SerializeField] private Vector3 playerStartPosition;
    public Vector3 PlayerStartPosition => playerStartPosition;
    [SerializeField] private Vector3 destination;
    public Vector3 Destination => destination;

    public UIManager uiManager;

    public float ElapsedTime { get; private set; }
    public bool IsCleared { get; private set; }

    private void Awake()
    {
        IsCleared = false;
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
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ClearStage()
    {
        IsCleared = true;
        Cursor.lockState = CursorLockMode.None;
        
        // TODO : 클리어 시간과 사용 폭탄 수 uiManager에 셋팅
        // ShowGameClearPanel에 파라미터를 추가하거나 해도 좋을 것 같습니다
        // 사용 폭탄 갯수 플레이어 말고 스테이지 매니저가 들고 있는 것도 좋을 것 같아요
        // 경과 시간은 Update에도 적혀있는 ElapsedTime 참고
        
        uiManager.ShowGameClearPanel();
    }

}
