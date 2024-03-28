using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonApproachAction : MegalodonFSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        brain.Movement.SetMoveSpeed(brain.Info.approachSpeed);
    }
}
