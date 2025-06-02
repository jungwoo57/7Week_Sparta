using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player; // �Ŵ��� �ν��Ͻ� �� �ش� �ڵ� �̱��濡�� ��������
    public TextMeshProUGUI bombCountText; // ����� ��ź ����
    public QuickSlot quickSlot;
    
    public TextMeshProUGUI bombName;
    public Image bombImage;

    public void UIUpdate()
    {
        bombCountText.text = " X " + Stage.Instance.usedBombCount;
        if (!player.curBombData)
        {
            bombName.text = "";
            bombImage.sprite = null;
            bombImage.gameObject.SetActive(false);
        }
        else
        {
            bombName.text = player.curBombData.bombName;
            bombImage.sprite = player.curBombData.icon;
            bombImage.gameObject.SetActive(true);
        }
    }
    
}
