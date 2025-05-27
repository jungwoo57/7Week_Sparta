
using TMPro;
using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    [SerializeField] 
    GameObject contentBox;
    
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject titlePanel;
    void Awake()
    {
        InitContentBox();
    }

    private void InitContentBox()
    {
        foreach (Transform child in contentBox.transform)
        {
            Destroy(child.gameObject);
        }
 
        for (int i = 0; i < 3; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab, contentBox.transform);
            SavedSlot slot = slotGO.GetComponent<SavedSlot>();
            slot.Init(i);
        }
    }

    public void OnClickBackButton()
    {
        titlePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
