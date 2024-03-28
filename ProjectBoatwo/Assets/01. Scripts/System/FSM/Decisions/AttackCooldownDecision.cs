using UnityEngine;

public class AttackCooldownDecision : FSMDecision
{
    [SerializeField] AttackTargetParams param = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        param = brain.GetFSMParam<AttackTargetParams>();
    }

    public override bool MakeDecision()
    {
        return param.IsCooldown;
    }
}
