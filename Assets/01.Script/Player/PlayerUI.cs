using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player; // 매니저 인스턴스 후 해당 코드 싱글톤에서 가져오기
    public TextMeshProUGUI bombCount; // 사용한 폭탄 갯수

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
        bombName.text = player.curBombData.bombName; // bombdata.name 으로 변경예정
    }
}
