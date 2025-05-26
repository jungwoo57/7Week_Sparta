using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BombType
{
    Bound,
    Demolition,
    Portal,
    Emp,
    Laser,
}

[CreateAssetMenu(menuName = "NewBomb", fileName = "Bomb")]

public class BombData : ScriptableObject
{
    [Header("Info")]
    public BombType bombType;
    public string bombName;
    public string description;
    public Sprite icon;
    public Color iconColor;
    public GameObject bombPrefab;
    
    [Header("Performance")]
    public float explodePower;
    public float explodeRange;
    public float explodeTime;
    public float bombCooldown;
    
    [Header("Stackable")]
    public bool stackable;
    public int maxStackAmount;
    
    [Header("Equip")]
    public GameObject equipPrefab;
    
    [Header("Sound")]
    public AudioClip explodeSound;
}
