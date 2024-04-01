using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : FSMAction
{
    private NavMovement movement = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        movement = brain.GetComponent<NavMovement>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        movement.SetDestination(brain.transform.position);
    }
}
