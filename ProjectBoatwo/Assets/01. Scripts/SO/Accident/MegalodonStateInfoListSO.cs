using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MegalodonStateInfo
{
    public MegalodonStateType stateType;
    public float MoveSpeed;
    public float FloatingOffset;
}

[CreateAssetMenu(menuName = "SO/Accident/Megalodon Info SO")]
public class MegalodonStateInfoListSO : ScriptableObject
{
    public List<MegalodonStateInfo> MegalodonStateInfoList;

    public MegalodonStateInfo GetStateInfo(MegalodonStateType _stateType)
    {
        return MegalodonStateInfoList.Find(x => x.stateType == _stateType);
    }
}
