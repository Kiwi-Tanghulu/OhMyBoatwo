using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAttackAction : MegalodonFSMAction
{
    [SerializeField] DetectTargetParams targetParam = null;
    [SerializeField] AttackTargetParams attackParam = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        targetParam = brain.GetFSMParam<DetectTargetParams>();
        attackParam = brain.GetFSMParam<AttackTargetParams>();
    }

    public override void EnterState()
    {
        //play attack animation
        Debug.Log("megalodon attack");
        if(targetParam.Target.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.OnDamaged(100f, brainTrm);
        }
        base.EnterState();
    }
}
