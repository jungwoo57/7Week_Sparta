using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BombType
{
    Demolition,
    Bound,
}

[CreateAssetMenu(menuName = "NewBomb", fileName = "Bomb")]

public class BombData : ScriptableObject
{
    [Header("Info")]
    public BombType bombType;
    public string name;
    public string description;
    public Sprite icon;
    public Color iconColor;
    public GameObject bombPrefab;
    
    [Header("Performance")]
    public float explodePower;
    public float explodeRange;
    public float explodeTime;

    [Header("Stack")]
    public int stackAmount;
}
