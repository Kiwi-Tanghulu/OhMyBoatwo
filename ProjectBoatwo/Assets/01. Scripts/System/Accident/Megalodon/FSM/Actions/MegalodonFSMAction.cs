using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMAction : FSMAction
{
    protected new MegalodonFSMBrain brain;
    protected Transform targetShipTrm;
    protected Transform brainTrm;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        this.brain = brain as MegalodonFSMBrain;
        Debug.Log(this.brain);
        Debug.Log(this.brain.TargetShip);
        targetShipTrm = this.brain.TargetShip.transform;
        brainTrm = this.brain.transform;
    }
}
