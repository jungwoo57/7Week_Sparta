using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStage : MonoBehaviour
{
    [Header("saveData")]
    [SerializeField] private int _id;
    public int Id => _id;
    [SerializeField] private StageState _stageState;

    public Player player;
    public StageState StageState
    {
        get => _stageState;
        set => _stageState = value;
    }

    [Header("MapData")]
    [SerializeField] private int _bombCount;
    [SerializeField] private Vector3 playerStartPosition;
    public Vector3 PlayerStartPosition => playerStartPosition;
    [SerializeField] private Vector3 destination;
    public Vector3 Destination => destination;
    public GameObject TestDestination;


    public void Start()
    {
        SetStage();
    }

    public void SetState(StageState state)
    {
        StageState = state;
    }

    public SaveData ToSaveData()
    {
        return new SaveData { id = _id, stageState = _stageState };
    }

    public void LoadFromSaveData(SaveData data)
    {
        StageState = data.stageState;
    }
    void SetStage()
    {
        player.transform.position = PlayerStartPosition;
        TestDestination.transform.position = Destination;
    }

}
