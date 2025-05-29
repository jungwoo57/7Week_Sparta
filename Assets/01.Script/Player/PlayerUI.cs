using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player; // �Ŵ��� �ν��Ͻ� �� �ش� �ڵ� �̱��濡�� ��������
    public TextMeshProUGUI bombCount; // ����� ��ź ����

    public TextMeshProUGUI bombName;
    public Image bombImage;

    private void Awake()
    {
    }

    private void Update()
    {
        UIUpdate();
    }
    private void UIUpdate()
    {
        bombCount.text = " X " + player.useBombCount.ToString();
        bombName.text = player.curBombData.bombName; // 
    }
}
