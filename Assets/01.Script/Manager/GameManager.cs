using UnityEngine;

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

    /**Stage class 구현 후
    private Stage _curStage;
    public Stage CurStage
    {
        get { return _curStage; }
    }*/

    /**Player class 구현 후
    public Player player;*/
    
    private void Awake()
    {
        Singleton();
    }

    public void Save()
    {

    }

    public void ExitGame()
    {

    }
}
