using UnityEngine;

public class TargetDetectDecision : FSMDecision
{
    [Space(15f)]
    [SerializeField] DetectTargetParams param = null;

    public override bool MakeDecision()
    {
        bool targetFound = param.Target != null;
        if(targetFound == false)
            return false;

        bool rangeCondition = param.Target.InnerDistance(transform, param.Radius);
        return rangeCondition;
    }
}
