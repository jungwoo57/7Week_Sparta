
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 임시

public class StageSelectButton : MonoBehaviour
{
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
    }

    public void OnClick()
    {
        
    }
}


