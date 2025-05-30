using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAffected
{ 
    public PlayerController controller;


    public Transform bombPos;
    public Transform bombSpawnPos;
    public BombBase[] bomb; 

    private int curBombIndex; 
    private int maxBombIndex;
    public int useBombCount; 
    public GameObject curBomb;
    public BombBase curBombData;
    public PlayerManager playerManager;
    PlayerUI playerUI;

    public float coolTime = 0;
    private Animator anim;
    private Rigidbody rigid;
    
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        useBombCount = 0;
        maxBombIndex = bomb.Length -1 ;
        curBombIndex = 0;

        curBombData = bomb[curBombIndex];
        curBomb = Instantiate(bomb[curBombIndex].equipPrefab, bombPos);
        curBomb.transform.position = bombPos.position;
    }

    private void Start()
    {
        Init();
    }

    void Update()
    {
        if(coolTime > 0)
        {
            coolTime -= Time.deltaTime;
            if (coolTime < 0) coolTime = 0;
        }
    }

    public void Init()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if(playerManager != null)
        {
            playerManager.Player = this;
        }
     
        playerUI = Stage.Instance.uiManager.playerUI;
        
        for (int i = 0; i < bomb.Length; i++)
        {
            playerUI.quickSlot.SetItemSprite(bomb[i].icon, i+1);
        }
    }
    public void SpawnBomb()
    {
        if (coolTime > 0) return;
        if (curBombIndex > maxBombIndex) return;
        GameObject spawnBomb = Instantiate(bomb[curBombIndex].bombPrefab);
        spawnBomb.transform.position = bombSpawnPos.position;
        spawnBomb.AddComponent<Rigidbody>();
        spawnBomb.AddComponent<BombAction>();
        anim.SetTrigger("SpawnBomb");
        coolTime = bomb[curBombIndex].bombCooldown;
        Stage.Instance.usedBombCount++;
        Stage.Instance.uiManager.playerUI.UIUpdate();
    }


    public void SwapBomb(int index)
    {
        playerUI.quickSlot.FocusSlot(index);
        curBombIndex = index - 1;
        
        if (curBomb != null)
        {
            Destroy(curBomb);
        }
        if (curBombIndex > maxBombIndex)
        {
            curBombData = null;
            Stage.Instance.uiManager.playerUI.UIUpdate();
            return;
        }
        curBombData = bomb[curBombIndex];
        curBomb = Instantiate(bomb[curBombIndex].equipPrefab, bombPos);
        curBomb.transform.position = bombPos.position;

        playerUI.UIUpdate();
    }

    public void OnAffected(Vector3 pos, float force, float radius, BombType type) 
    {
        if(type == BombType.Bound)
        {
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    public int GetCurBombIndex()
    {
        return curBombIndex;
    }
}
