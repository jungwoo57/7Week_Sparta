
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Stackable,
    Distinct
}
public class TestItemData
{
    public string name;
    public ItemType itemType;
    public Sprite sprite;
}
public class ItemSlot : MonoBehaviour
{
    private TestItemData item;
    [SerializeField] Image itemIcon;
    [SerializeField] Image coolDownIndicator;
    [SerializeField] TextMeshProUGUI itemCountText;
    [SerializeField] private Outline outline;
    private int itemCount;
    private void Awake()
    {
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            Debug.Log("?");
        }
        outline.enabled = false;
        EmptySlot();
    }
    
    public void SetItem(TestItemData _item)
    {
        item = _item;
        itemIcon.sprite = _item.sprite;
        if (item.itemType == ItemType.Stackable)
        {
            itemCountText.gameObject.SetActive(true);
            itemCount = 0;
            itemCountText.text = itemCount.ToString();
        }
    }

    public void AddItemCount()
    {
        itemCount++;
        itemCountText.text = itemCount.ToString();
    }

    public void SetCooldownPercent(float percent)
    {
        coolDownIndicator.fillAmount = percent;
    }
    
    private void EmptySlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemCountText.gameObject.SetActive(false);
        coolDownIndicator.fillAmount = 0;
    }

    public void ToggleOutline()
    {
        outline.enabled = !outline.enabled;
    }
}
