
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedSlot : MonoBehaviour
{
    [SerializeField]
    private Image thumbnail;
    [SerializeField]
    private TextMeshProUGUI progressText;

    [SerializeField]
    private TextMeshProUGUI elapsedTimeText;

    [SerializeField]
    private int idx;
    
    public void Init(int _idx)
    {
        idx = _idx;
    }
    public void OnClickSlot()
    {
        // Save
    }
}
