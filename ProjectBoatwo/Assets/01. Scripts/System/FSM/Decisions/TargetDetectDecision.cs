using UnityEngine;

public class TargetDetectDecision : FSMDecision
{
    [Space(15f)]
    [SerializeField] DetectTargetParams param = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        param = brain.GetFSMParam<DetectTargetParams>();
    }

    public override bool MakeDecision()
    {
        bool targetFound = param.Target != null;
        if(targetFound == false)
            return false;

        bool rangeCondition = param.Target.InnerDistance(transform, param.Radius);
        return rangeCondition;
    }
}
