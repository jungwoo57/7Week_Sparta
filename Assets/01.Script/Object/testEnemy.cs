using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class testEnemy : MonoBehaviour, IAffected
{
    bool isCondition = false;
    public void OnAffected(Vector3 pos, float force, float radius, BombType bombType)
    {
        if (isCondition) return;

        switch (bombType)
        {
            case BombType.Emp:
                StartCoroutine(Stunned());
                break;
            case BombType.Ice:
                StartCoroutine(Freeze());
                break;
            case BombType.Flame:
                StartCoroutine(Burn());
                break;
        }
    }

    IEnumerator Stunned()
    {
        isCondition = true;
        Debug.Log("EMP 작동");
        yield return new WaitForSeconds(5f);
        Debug.Log("EMP 해제");
        isCondition = false;
    }
    IEnumerator Freeze()
    {
        isCondition = true;
        Debug.Log("얼어붙음");
        yield return new WaitForSeconds(5f);
        Debug.Log("녹음");
        isCondition = false;
    }
    IEnumerator Burn()
    {
        isCondition = true;
        Debug.Log("불탐");
        yield return new WaitForSeconds(5f);
        Debug.Log("꺼짐");
        isCondition = false;
    }
}
