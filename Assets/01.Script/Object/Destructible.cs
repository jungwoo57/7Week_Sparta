using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class Destructible : MonoBehaviour, IAffected
{
    [SerializeField] private float maxHealth;
    private float curHealth;

    private void Awake()
    {
        curHealth = maxHealth;
    }

    public void OnAffected(Vector3 pos, float force, float radius, BombType type)
    {
        if (type != BombType.Emp)
        {
            curHealth -= force;
            if (curHealth <= 0f)
            {
                Break();
            }
        }
    }
    private void Break()
    {
        Destroy(gameObject);
    }
}
