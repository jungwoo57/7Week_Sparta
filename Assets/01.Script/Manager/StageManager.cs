using UnityEngine;

public class StageManager : MonoBehaviour
{
    private Stage _curStage;
    public Stage CurStage
    {
        get { return _curStage; }
    }

    private void Awake()
    {
    }

    private void Start()
    {
        GameManager.Instance.SaveLoadManager.LoadData();
    }

    public void LoadStage(Stage stage)
    {
        _curStage = stage;
        /**
        player.transform = _curStage.PlayerTransformInfo (이런 느낌?)
        camera.transform = _curStage.CameraInfo (이런 느낌?)
        */
    }

    public void ClearStage()
    {
        /**
        스테이지 인덱스++
        _curStage = nextStage
        LoadStage(_curStage);
        */
    }
}
