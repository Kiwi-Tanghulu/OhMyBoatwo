using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonThreatState : FSMState
{
    private float threatDistance;

    private float stateTime;
    private float attackDelay;

    public override void EnterState()
    {
        base.EnterState();

        stateTime = 0f;
    }
}
