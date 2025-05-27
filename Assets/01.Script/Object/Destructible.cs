using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class Destructible : MonoBehaviour, IAffected
{
    public void OnAffected(Vector3 pos, float force, float radius, BombType type)
    {
        if(type == BombType.Emp) return;
        
        Destroy(gameObject);
    }
}
