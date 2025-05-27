using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField]
    private List<ItemSlot> itemSlots;

    [SerializeField]
    private GameObject contentBox;

    private int focusedIndex;   // 슬롯 번호 기준. 맨앞이 1입니다
    private void Awake()
    {
        itemSlots = new List<ItemSlot>();
        foreach (ItemSlot slot in contentBox.GetComponentsInChildren<ItemSlot>())
        {
            itemSlots.Add(slot);
        }

        
    }

    private void Start()
    {
        itemSlots[0].ToggleOutline();
    }

    private void FocusSlot(int x)
    {
        int index = x - 1;
        itemSlots[focusedIndex-1].ToggleOutline();
        itemSlots[index].ToggleOutline();
    }
}
