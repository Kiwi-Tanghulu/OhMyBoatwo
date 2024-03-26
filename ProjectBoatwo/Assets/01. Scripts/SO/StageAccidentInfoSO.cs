using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageAccidentInfo
{
    public float startTime;
    public Accident accident;
}

[CreateAssetMenu(menuName = "SO/StageAccidentInfo")]
public class StageAccidentInfoSO : ScriptableObject
{
    public List<StageAccidentInfo> stageAccidentInfos;
}
