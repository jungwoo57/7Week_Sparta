using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour, IAffected
{
    bool isCondition = false;
    BombBase _data;
    public void OnAffected(Vector3 pos, float force, float radius, BombType bombType)
    {
        if (isCondition) return;

        switch (bombType)
        {
            case BombType.Laser:
                StartCoroutine(Laser());
                break;
            case BombType.Freeze:
                StartCoroutine(Freeze());
                break;
        }
    }

    private IEnumerator Laser()
    {
        // else if (target.CompareTag("Interactable"))
        // {
        //     //대강 요런 느낌..?
        //     //IInteractable interactable = target.GetComponent<IInteractable>();
        //     // if (interactable != null)
        //     // {
        //     //     interactable.Interact();
        //     // }
        // }
        yield return null;
    }

    private IEnumerator Freeze()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        Animator anim = GetComponent<Animator>();
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
