
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // public static UIManager Instance {get; private set;}
    //
    // private void Awake()
    // {
    //     if (!Instance)
    //     {
    //         Instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public GameClearPanel gameClearPanel;

    private void Start()
    {
        GameManager.Instance.StageManager.uiManager = this;
        gameClearPanel.gameObject.SetActive(false);
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.gameObject.SetActive(true);
    }

    #region UISharedMethods

  
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Seunghwa_TitleScene");
    }

    #endregion
}
