using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestination : MonoBehaviour
{
    void OnDestination()
    {
        GameManager.Instance.StageManager.ClearStage();
        Debug.Log("��ǥ ����");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnDestination(); // ���� ���� UI ���
        }
    }
}
