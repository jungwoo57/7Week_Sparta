using UnityEngine;

public enum StageState
{
    Locked,
    Open,
    Cleared
}

public class Stage : ScriptableObject
{
    [Header("saveData")]
    private int _id;
    private StageState _stageState;

    private int bombCount;
}
