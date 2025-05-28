using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombStatus : MonoBehaviour
{
    public BombBase data;
    private BombAction _action;

    private void Awake()
    {
        _action = this.gameObject.GetComponent<BombAction>();
    }

    public void PowerUp(int power)
    {
        data.explodePower += power;
    }

    public void RangeUp(int range)
    {
        data.explodeRange += range;
    }

    public void CoolTimeDown(float time)
    {
        if (time < data.bombCooldown)
        {
            data.bombCooldown -= time;
        }
        else
        {
            data.bombCooldown = 0f;
        }
    }
}
