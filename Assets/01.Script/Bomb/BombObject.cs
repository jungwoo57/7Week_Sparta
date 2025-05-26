using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public BombData data;
    //private Collider _collider;

    private void OnEnable()
    {
        //_collider = this.gameObject.GetComponent<Collider>();
        
        PlacedType();
    }
    
    //폭탄 종류 확인 메서드
    private void PlacedType()
    {
        switch (data.bombType)
        {
            case BombType.Bound:
            case BombType.Demolition:
            case BombType.Emp:
            case BombType.Laser:
                Explode();
                break;
            case BombType.Portal:
                Install();
                break;
        }
    }
    
    //폭탄 폭발 메서드
    private void Explode()
    {
        Debug.Log(data.bombType);
        Debug.Log("붐!");
    }

    private void Install()
    {
        var target = FindObjectsOfType<BombObject>();
        int count = 0;
        
        for (int i = 0; i < target.Length; i++)
        {
            Debug.Log(target[i].data.bombType);
            
            if (target[i].data.bombType == BombType.Portal)
            {
                count++;
            }
        }

        if (count == 1)
        {
            Debug.Log("포탈 준비 중");
        }
        else if (count == 2)
        {
            Debug.Log("포탈 설치 완료");
        }
    }

    private void OnDisable()
    {
        
    }
}
