
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameClearPanel;

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
