using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class testEnemy : MonoBehaviour, IAffected
{
    
    public void OnAffected(Vector3 pos, float force, float radius, BombType bombType)
    {
        if (bombType == BombType.Emp)
        {
            StartCoroutine(Stunned());
        }
        if (bombType == BombType.Ice)
        {
            StartCoroutine(Freeze());
        }
        if (bombType == BombType.Flame)
        {
            StartCoroutine(Burn());
        }
    }

    IEnumerator Stunned()
    {
        Debug.Log("EMP 작동");
        yield return new WaitForSeconds(5f);
        Debug.Log("EMP 해제");
    }
    IEnumerator Freeze()
    {
        Debug.Log("얼어붙음");
        yield return new WaitForSeconds(5f);
        Debug.Log("녹음");
    }
    IEnumerator Burn()
    {
        Debug.Log("불탐");
        yield return new WaitForSeconds(5f);
        Debug.Log("꺼짐");
    }
}
