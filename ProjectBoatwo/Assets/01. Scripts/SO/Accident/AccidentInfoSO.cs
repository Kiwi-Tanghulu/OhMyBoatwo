using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Accident/InfoSO")]
public class AccidentInfoSO : ScriptableObject
{
    public AccidentType AccidentType;
    public string StartNoticeText;
}
