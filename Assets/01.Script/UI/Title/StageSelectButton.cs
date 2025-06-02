
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 임시

public class StageSelectButton : MonoBehaviour
{

    //private Stage stage;
    [SerializeField]
    private int id;

    private Button buttonComponent;
    
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
    }

    public void Init(StageData saveData)
    {
        id = saveData.id;
        buttonText.text = "Stage " + (saveData.id + 1);
        
        if(saveData.stageState == StageState.Locked)
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
        // SceneManager.LoadScene("Seunghwa_JWPlayerCopy_InGameUI");
        TitleSceneAssistant.Instance.ActionAfterFadeOut(() =>  GameManager.Instance.StageManager.LoadStage(id + 1));
        //TitleSceneAssistant.Instance.ActionAfterFadeOut(() =>  GameManager.Instance.StageManager.LoadStage());
    }
}


