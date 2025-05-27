using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affected : MonoBehaviour, IAffected
{
    public void OnAffected(Vector3 pos, float force, float radius)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (rigid != null)
        {
            rigid.AddExplosionForce(force, pos, radius);
        }
    }
}
