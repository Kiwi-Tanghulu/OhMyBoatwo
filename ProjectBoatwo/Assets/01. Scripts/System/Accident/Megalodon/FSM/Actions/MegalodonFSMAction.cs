using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMAction : FSMAction
{
    protected MegalodonFSMBrain _brain;
    protected Transform targetShipTrm;
    protected Transform brainTrm;

    private Buoyancy buoyancy;

    [SerializeField] protected MegalodonStateType stateType;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        this._brain = brain as MegalodonFSMBrain;
        
        brainTrm = this._brain.transform;
        buoyancy = brain.GetComponent<Buoyancy>();
    }

    public override void EnterState()
    {
        base.EnterState();

        MegalodonStateInfo stateInfo = _brain.Info.GetStateInfo(stateType);
        if (stateInfo != null)
        {
            _brain.Movement.SetMoveSpeed(stateInfo.MoveSpeed);
            buoyancy.SetFloatingOffset(stateInfo.FloatingOffset);
        }
        else
            Debug.LogError($"no exist state info : {stateType}");
        
        targetShipTrm = Ship.Instance.transform;
    }
}
