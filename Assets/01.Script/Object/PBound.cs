using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBound : MonoBehaviour, IAffected
{
    public void OnAffected(Vector3 pos, float force, float radius, BombType type)
    {
        if (type != BombType.Bound) return;

        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Vector3.up *  force, ForceMode.Impulse);
    }
}
