using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLocation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StageManager.ClearStage();
        }
    }
}
