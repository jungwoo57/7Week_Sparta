using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerUI playerUI;
    public GameClearPanel gameClearPanel;
    public PausePanel pausePanel;

    [SerializeField]
    private Fade fadeSquare;
    
    StageManager stageManager;
    private void Start()
    {
        stageManager = GameManager.Instance.StageManager;
        gameClearPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        fadeSquare.FadeIn();
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
        Time.timeScale = 1;
        StartCoroutine(AfterFadeOut(stageManager.Restart));
        
    }
    
    // 게임 실패가 있을 시 그 UI에서도 사용하기 위해 여기에 둡니다
    // 재시작 액션도 저 UI가 필요하면 여기로 옮기겠습니다
   
    public void OnClickQuit()
    {
        Time.timeScale = 1;
        StartCoroutine(AfterFadeOut(() => SceneManager.LoadScene("TitleScene")));
        
    }

    #endregion

    public void FadeIn()
    {
        fadeSquare.FadeIn();
    }

    public void FadeOut()
    {
        fadeSquare.FadeOut();
    }

    IEnumerator AfterFadeOut(Action action)
    {
        FadeOut();
        yield return new WaitForSeconds(1f);
        action?.Invoke();
    }
  
}
