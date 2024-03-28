using UnityEngine;

public class AttackRangeDecision : FSMDecision
{
	[SerializeField] DetectTargetParams targetParam = null;
	[SerializeField] AttackTargetParams attackParam = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        targetParam = brain.GetFSMParam<DetectTargetParams>();
        attackParam = brain.GetFSMParam<AttackTargetParams>();
    }

    public override bool MakeDecision()
    {
        return targetParam.Target.InnerDistance(transform, attackParam.AttackRange);
    }
}
