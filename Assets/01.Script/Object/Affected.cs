using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class Affected : MonoBehaviour, IAffected
{
    public void OnAffected(Vector3 pos, float force, float radius, BombType type)
    {
        /*if(type != TestBombType.Basic) return;
        
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid?.AddExplosionForce(force, pos, radius);
        */
    }
}
