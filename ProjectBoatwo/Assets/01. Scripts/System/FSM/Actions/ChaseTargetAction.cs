using UnityEngine;

public class ChaseTargetAction : FSMAction
{
    [SerializeField] DetectTargetParams param = null;
    private NavMovement movement = null;
    private HumanoidAnimator animator = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        movement = brain.GetComponent<NavMovement>();
        animator = brain.transform.Find("Visual").GetComponent<HumanoidAnimator>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        movement.SetDestination(param.Target.position);
        animator.ToggleWalk(true);
    }

    public override void ExitState()
    {
        base.ExitState();
        movement.StopImmediately();
        animator.ToggleWalk(false);
    }
}
