using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAffected
{ 
    public PlayerController controller;


    public Transform bombPos; // �÷��̾ ��ź ����ִ� ��ġ
    public Transform bombSpawnPos; // ��ź ��ȯ ��ġ
    public BombBase[] bomb; // ������������ �ʿ��� ��ź ���� �޾ƿ�

    private int curBombIndex; // ���� ��� �ִ� ��ź��ȣ
    private int maxBombIndex; // ����� ��ź ���� �� �ְ�ġ ����
    public int useBombCount; // ����� ��ź �� ��
    public GameObject curBomb; //���� ��� �ִ� ��ź
    public BombBase curBombData;

    private Animator anim;
    private Rigidbody rigid;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        useBombCount = 0;
        maxBombIndex = bomb.Length -1 ;
        curBombIndex = 0;

        curBombData = bomb[curBombIndex];
        curBomb = Instantiate(bomb[curBombIndex].bombPrefab, bombPos);
        curBomb.transform.position = bombPos.position;
    }
    public void SpawnBomb()
    {
        GameObject spawnBomb = Instantiate(bomb[curBombIndex].bombPrefab);
        spawnBomb.transform.position = bombSpawnPos.position;
        spawnBomb.AddComponent<Rigidbody>();
        spawnBomb.AddComponent<BombAction>();
        useBombCount++;
        anim.SetTrigger("SpawnBomb");
    }


    public void SwapBomb(int index)
    {
        curBombIndex = index - 1;
        if (curBombIndex >= maxBombIndex)
        {
            curBombIndex = maxBombIndex;

        }
        if (curBomb != null)
        {
            Destroy(curBomb);
        }
        curBombData = bomb[curBombIndex];
        curBomb = Instantiate(bomb[curBombIndex].bombPrefab, bombPos);
        curBomb.transform.position = bombPos.position;
    }

    public void OnAffected(Vector3 pos, float force, float radius, BombType type) 
    {
        if(type == BombType.Bound)
        {
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
