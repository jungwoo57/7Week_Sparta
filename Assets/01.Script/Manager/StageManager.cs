using UnityEngine;

public class Stage
{
    // 추후 Stage.cs 구현되면 제거
}

public class StageManager : MonoBehaviour
{
    #region Singleton
    private static StageManager _instance;
    public static StageManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("StageManager").AddComponent<StageManager>();
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
    
    private Stage _curStage;
    public Stage CurStage
    {
        get { return _curStage; }
    }


    private void Awake()
    {
        Singleton();
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
