using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BombAction : MonoBehaviour
{
    private Collider _collider;
    private BombStatus _status;
    protected BombData _data;
    

    private void Awake()
    {
        _collider = this.gameObject.GetComponent<Collider>();
        _collider.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        StartCoroutine(Explode());
    }

    private void Init()
    {
        _status = this.gameObject.GetComponent<BombStatus>();
        _data = _status.data;
    }

    public IEnumerator Explode()
    {
        Init();
        yield return new WaitForSeconds(_data.explodeTime);
        float time = 0f;
        while (time < 1f)
        {
            _collider.transform.localScale = Vector3.Lerp(Vector3.one * _data.explodeRange, Vector3.zero, time);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_data.bombType == BombType.Bound)
        {
            Bound(other);
        }
        else if (_data.bombType == BombType.Demolition)
        {
            Demolition(other);
        }
        else if (_data.bombType == BombType.Laser)
        {
            Laser(other);
        }
        else if (_data.bombType == BombType.Freeze)
        {
            StartCoroutine(Freeze(other));
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
            rigid.AddForce(Vector3.up * _data.explodePower, ForceMode.Impulse);
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

    private void Laser(Collider target)
    {
        if (target == null)
        {
            Debug.Log("Target is null");
        }
        // else if (target.CompareTag("Interactable"))
        // {
        //     //대강 요런 느낌..?
        //     //IInteractable interactable = target.GetComponent<IInteractable>();
        //     // if (interactable != null)
        //     // {
        //     //     interactable.Interact();
        //     // }
        // }
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
            
            yield return new WaitForSeconds(_data.freezeDuration);
            
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
}
