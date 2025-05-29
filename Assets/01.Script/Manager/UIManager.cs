
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
        Stage.Instance.uiManager = this;
        gameClearPanel.gameObject.SetActive(false);
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.gameObject.SetActive(true);
    }

    #region UISharedMethods

  
    
    // 게임 실패가 있을 시 그 UI에서도 사용하기 위해 여기에 둡니다
    // 재시작 액션도 저 UI가 필요하면 여기로 옮기겠습니다
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Seunghwa_TitleScene");
    }

    #endregion
}
