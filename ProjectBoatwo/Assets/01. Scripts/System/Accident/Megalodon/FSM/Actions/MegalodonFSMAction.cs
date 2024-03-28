using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMAction : FSMAction
{
    protected new MegalodonFSMBrain brain;
    protected Transform targetShipTrm;
    protected Transform brainTrm;

    private Buoyancy buoyancy;

    [SerializeField] protected MegalodonStateType stateType;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        this.brain = brain as MegalodonFSMBrain;
        
        brainTrm = this.brain.transform;
        buoyancy = brain.GetComponent<Buoyancy>();
    }

    public override void EnterState()
    {
        base.EnterState();

        MegalodonStateInfo stateInfo = brain.Info.GetStateInfo(stateType);
        if (stateInfo != null)
        {
            brain.Movement.SetMoveSpeed(stateInfo.MoveSpeed);
            buoyancy.SetFloatingOffset(stateInfo.FloatingOffset);
        }
        else
            Debug.LogError($"no exist state info : {stateType}");
        
        targetShipTrm = Ship.Instance.transform;
    }
}
