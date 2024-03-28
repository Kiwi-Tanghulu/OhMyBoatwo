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
        targetShipTrm = this.brain.targetShip.transform;
        brainTrm = this.brain.transform;
    }
}
