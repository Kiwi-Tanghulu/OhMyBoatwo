using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonRunAction : MegalodonFSMAction
{
    public override void EnterState()
    {
        base.EnterState();
        Vector3 moveDir = (transform.position - targetShipTrm.position).normalized;
        _brain.Movement.SetMoveDir(moveDir);
    }
}
