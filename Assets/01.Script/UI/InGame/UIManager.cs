
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

    public GameObject gameClearPanel;

    private void Start()
    {
        GameManager.Instance.StageManager.uiManager = this;
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
    }

    #region UISharedMethods

  
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Seunghwa_TitleScene");
    }

    #endregion
}
