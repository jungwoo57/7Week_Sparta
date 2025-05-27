using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public BombData data;
    private Collider _collider;

    private void OnEnable()
    {
        _collider = this.gameObject.GetComponent<Collider>();
        _collider.transform.localScale = Vector3.zero;
        PlacedType();
    }
    
    //폭탄 종류 확인 메서드
    private void PlacedType()
    {
        switch (data.bombType)
        {
            case BombType.Bound:
            case BombType.Demolition:
            case BombType.Freeze:
            case BombType.Laser:
                StartCoroutine(Explode());
                break;
            case BombType.Portal:
                Install();
                break;
        }
    }
    
    //폭탄 폭발 메서드
    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(data.explodeTime);
        float time = 0f;
        while (time < 1f)
        {
            _collider.transform.localScale = Vector3.Lerp(Vector3.one * data.explodeRange, Vector3.zero, time);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void Bound(Collider target)
    {
        if (target == null)
        {
            Debug.Log("Target is null");
        }
        else if (target.CompareTag("Player"))
        {
            var rigid = target.GetComponent<Rigidbody>();
            rigid.AddForce(Vector3.up * data.explodePower, ForceMode.Impulse);
        }
    }

    private void Demolition(Collider target)
    {
        if (target == null)
        {
            Debug.Log("Target is null");
        }
        else if (target.CompareTag("Destroyable"))
        {
            target.gameObject.SetActive(false);
        }
    }

    private IEnumerator Freeze(Collider target)
    {
        if (target == null)
        {
            Debug.Log("Target is null");
        }
        else if (target.CompareTag("Enemy"))
        {
            var rigid = target.GetComponent<Rigidbody>();
            var anim = target.GetComponent<Animator>();
            var enemySpeed = rigid.velocity;
            
            rigid.velocity = Vector3.zero;
            anim.speed = 0f;
            
            yield return new WaitForSeconds(data.freezeDuration);
            
            float time = 0f;
            while (time < 1f)
            {
                rigid.velocity = Vector3.Lerp(Vector3.zero, enemySpeed, time);
                anim.speed = Mathf.Lerp(0f, 1f, time);
                time += Time.deltaTime;
                yield return null;
            }
        }
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
    
    /* 폭탄을 설치
     * 폭탄 폭발
     * 폭탄 종류에 따라 효과 발생
     */
}
