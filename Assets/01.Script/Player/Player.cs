using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public PlayerController controller;


    public Transform bombPos; // 플레이어가 폭탄 들고있는 위치
    public Transform bombSpawnPos; // 폭탄 소환 위치
    public GameObject[] bomb; // 스테이지에서 필요한 폭탄 갯수 받아옴

    private int curBombIndex; // 현재 들고 있는 폭탄번호
    private int maxBombIndex; // 사용할 폭탄 종류 수 최개치 설정
    public int useBombCount; // 사용한 폭탄 갯 수
    public GameObject curBomb; //지금 들고 있는 폭탄
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
        // 스테이지에서 폭탄 종료 받아와서 bomb에 할당
        useBombCount = 0;
        maxBombIndex = bomb.Length -1 ;
        curBombIndex = 0;
        curBomb = Instantiate(bomb[curBombIndex], bombPos);
        curBomb.transform.position = bombPos.position;
        Debug.Log("초기화 완료");
    }
    public void SpawnBomb()
    {
        // 폭탄 데이터 쿨타임 불러와서 쿨타임 아닐 때 소환
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
        Debug.Log("폭탄이 바뀌었습니다" + curBombIndex);
    }
}
