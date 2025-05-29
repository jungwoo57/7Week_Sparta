
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameClearPanel gameClearPanel;
    public PausePanel pausePanel;
    
    StageManager stageManager;
    private void Start()
    {
        stageManager = GameManager.Instance.StageManager;
        Stage.Instance.uiManager = this;
        gameClearPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.gameObject.SetActive(true);
    }
    public void ShowPausedPanel()
    {
        pausePanel.gameObject.SetActive(true);
    }
    public void HidePausedPanel()
    {
        pausePanel.gameObject.SetActive(false);
    }

    #region UISharedMethods

    public void OnClickRetryButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        stageManager.Restart();
    }
    
    // 게임 실패가 있을 시 그 UI에서도 사용하기 위해 여기에 둡니다
    // 재시작 액션도 저 UI가 필요하면 여기로 옮기겠습니다
   
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Seunghwa_TitleScene");
    }

    #endregion


  
}
