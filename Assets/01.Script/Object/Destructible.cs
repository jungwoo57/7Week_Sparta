using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IAffected
{
    public void OnAffected(Vector3 pos, float force, float radius)
    {
        Destroy(gameObject);
    }
}
