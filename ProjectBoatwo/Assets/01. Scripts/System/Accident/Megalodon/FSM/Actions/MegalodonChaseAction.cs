using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonChaseAction : MegalodonFSMAction
{
    private Vector3 moveDir;

    public override void EnterState()
    {
        base.EnterState();

        brain.Movement.SetMoveSpeed(brain.Info.chaseSpeed);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        moveDir = targetShipTrm.position - brainTrm.position;
        moveDir.y = 0;
        moveDir.Normalize();

        brain.Movement.SetMoveDir(moveDir);
    }
}
