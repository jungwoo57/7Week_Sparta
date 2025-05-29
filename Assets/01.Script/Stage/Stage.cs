using UnityEngine;

public class Stage : MonoBehaviour
{
    /**
    [Header("saveData")]
    [SerializeField]private int _id;
    public int Id => _id;
    [SerializeField] private StageState _stageState;
    public StageState StageState
    {
        get => _stageState;
        set => _stageState = value;
    }*/

    [Header("MapData")]
    [SerializeField] private int _bombCount;
    [SerializeField] private Vector3 playerStartPosition;
    public Vector3 PlayerStartPosition => playerStartPosition;
    [SerializeField] private Vector3 destination;
    public Vector3 Destination => destination;
}
