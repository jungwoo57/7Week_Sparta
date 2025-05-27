
using System;
using System.Collections.Generic;

public enum StageState
{
    Open,
    Cleared,
    Locked
}

[Serializable]
public class Progress
{
    public List<StageInfo> stages;
}

[Serializable]
public class StageInfo
{
    public int id;
    public StageState state;
    public string jsonPath;
}