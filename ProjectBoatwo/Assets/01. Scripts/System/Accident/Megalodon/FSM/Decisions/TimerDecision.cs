using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDecision : FSMDecision
{
    [SerializeField] private float transTime;
    private float remainTransTime;

    public override void EnterState()
    {
        base.EnterState();

        remainTransTime = transTime;
    }

    public override bool MakeDecision()
    {
        remainTransTime -= Time.deltaTime;

        return remainTransTime <= 0f;
    }
}
