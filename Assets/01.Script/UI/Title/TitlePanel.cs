
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject saveSlotPanel;

    public void OnClickStartButton()
    {
        // SceneManager.LoadScene 혹은 필요하면 비동기 로드씬 매니저
    }

    public void OnClickLoadButton()
    {
        saveSlotPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
