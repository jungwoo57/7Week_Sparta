
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 임시

public class StageSelectButton : MonoBehaviour
{
    // Stage를 쓰거나 id를 활용해서 게임 씬에서 의도한 스테이지가 로드되도록
    private StageInfo stage;
    [SerializeField]
    private int id;

    private Button buttonComponent;
    
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
    }

    public void Init(StageInfo _stage)
    {
        stage = _stage;
        buttonText.text = "Stage " + stage.id;
        
        if(stage.state == StageState.Locked)
            buttonComponent.interactable = false;
        buttonComponent.onClick.AddListener(OnClick);
    }

    // public void Init(int _id)
    // {
    //     id = _id;
    //     buttonText.text = "Stage " + id + 1;
    //     
    //     if(stage.state == StageState.Locked)
    //         buttonComponent.interactable = false;
    // }

    public void OnClick()
    {
        SceneManager.LoadScene("Seunghwa_JWPlayerCopy_InGameUI");
        GameManager.Instance.StageManager.Init();
    }
}


