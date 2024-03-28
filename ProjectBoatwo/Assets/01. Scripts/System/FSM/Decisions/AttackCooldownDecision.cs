using UnityEngine;

public class AttackCooldownDecision : FSMDecision
{
    [SerializeField] AttackTargetParams param = null;

    public override bool MakeDecision()
    {
        return param.IsCooldown;
    }
}
