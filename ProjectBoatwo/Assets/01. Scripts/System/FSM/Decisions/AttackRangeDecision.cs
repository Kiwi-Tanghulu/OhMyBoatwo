using UnityEngine;

public class AttackRangeDecision : FSMDecision
{
	[SerializeField] DetectTargetParams targetParam = null;
	[SerializeField] AttackTargetParams attackParam = null;

    public override bool MakeDecision()
    {
        return targetParam.Target.InnerDistance(transform, attackParam.AttackRange);
    }
}
