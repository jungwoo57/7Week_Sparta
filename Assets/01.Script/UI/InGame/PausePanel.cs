using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnClickResumeButton()
    {
        Stage.Instance.ResumeStage();
    }
}
