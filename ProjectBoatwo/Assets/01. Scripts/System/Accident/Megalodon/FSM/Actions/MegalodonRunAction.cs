using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonRunAction : MegalodonFSMAction
{
    public override void EnterState()
    {
        base.EnterState();

        brain.Movement.SetMoveSpeed(brain.Info.runSpeed);
        Vector3 moveDir = (transform.position - targetShipTrm.position).normalized;
        brain.Movement.SetMoveDir(moveDir);
    }
}
