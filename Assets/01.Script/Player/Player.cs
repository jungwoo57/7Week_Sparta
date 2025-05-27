using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public PlayerController controller;


    public Transform bombPos; // �÷��̾ ��ź ����ִ� ��ġ
    public Transform bombSpawnPos; // ��ź ��ȯ ��ġ
    public GameObject[] bomb; // ������������ �ʿ��� ��ź ���� �޾ƿ�

    private int curBombIndex; // ���� ��� �ִ� ��ź��ȣ
    private int maxBombIndex; // ����� ��ź ���� �� �ְ�ġ ����
    public int useBombCount; // ����� ��ź �� ��
    public GameObject curBomb; //���� ��� �ִ� ��ź
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        // ������������ ��ź ���� �޾ƿͼ� bomb�� �Ҵ�
        useBombCount = 0;
        maxBombIndex = bomb.Length -1 ;
        curBombIndex = 0;
        curBomb = Instantiate(bomb[curBombIndex], bombPos);
        curBomb.transform.position = bombPos.position;
        Debug.Log("�ʱ�ȭ �Ϸ�");
    }
    public void SpawnBomb()
    {
        // ��ź ������ ��Ÿ�� �ҷ��ͼ� ��Ÿ�� �ƴ� �� ��ȯ
        GameObject spawnBomb = Instantiate(bomb[curBombIndex]);
        spawnBomb.transform.position = bombSpawnPos.position;
        spawnBomb.AddComponent<Rigidbody>();
        useBombCount++;
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
        curBomb = Instantiate(bomb[curBombIndex], bombPos);
        curBomb.transform.position = bombPos.position;
        Debug.Log("��ź�� �ٲ�����ϴ�" + curBombIndex);
    }
}
