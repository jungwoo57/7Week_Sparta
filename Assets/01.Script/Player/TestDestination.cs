using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestination : MonoBehaviour
{
    void OnDestination()
    {
        Debug.Log("목표 도착");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnDestination(); // 게임 종료 UI 출력
        }
    }
}
