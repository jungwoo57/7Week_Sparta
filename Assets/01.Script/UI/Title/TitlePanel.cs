
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject stageSelectPanel;

    [SerializeField]
    private GameObject saveSlotPanel;

    public void OnClickStartButton()
    {
        stageSelectPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    
    // 지금은 안 쓰는 코드 (최종까지 필요 없을 시 제거 필요)
    public void OnClickLoadButton()
    {
        saveSlotPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
