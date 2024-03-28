using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonThreatAction : MegalodonFSMAction
{
    private float threatDistance;
    [SerializeField] private DetectTargetParams detectTargetParams;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        threatDistance = detectTargetParams.Radius;
    }

    public override void EnterState()
    {
        base.EnterState();

        brain.Movement.SetMoveSpeed(brain.Info.threatSpeed);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector3 targetPos = (brainTrm.position - targetShipTrm.position).normalized * threatDistance + targetShipTrm.position;
        targetPos += Quaternion.Euler(0f, 90f, 0f) * targetPos.normalized;
        Vector3 dir = (targetPos - brainTrm.position).normalized;
        dir.y = 0;
        brain.Movement.SetMoveDir(dir);
    }
}
