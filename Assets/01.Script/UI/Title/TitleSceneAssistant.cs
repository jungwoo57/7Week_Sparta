using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneAssistant : MonoBehaviour
{
    public static TitleSceneAssistant Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private Fade fadeSquare;

    public void ActionAfterFadeOut(Action action)
    {
        fadeSquare.FadeOut();
        StartCoroutine(AfterFade(action));
    }

    IEnumerator AfterFade(Action action)
    {
        yield return new WaitForSeconds(1);
        action?.Invoke();
    }
}
