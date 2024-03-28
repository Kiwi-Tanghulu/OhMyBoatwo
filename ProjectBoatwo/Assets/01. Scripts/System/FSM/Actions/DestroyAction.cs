using System;
using UnityEngine;

public class DestroyAction : FSMAction
{
	[SerializeField] float postponeTime = 1f;

    private HumanoidAnimator animator = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        animator = brain.transform.Find("Visual").GetComponent<HumanoidAnimator>();
    }

    public override void EnterState()
    {
        base.EnterState();

        animator.OnAnimationEndEvent += HandleAnimationEnd;
    }

    private void HandleAnimationEnd()
    {
        StartCoroutine(this.DelayCoroutine(postponeTime, HandleDestroy));
    }

    public override void ExitState()
    {
        base.ExitState();

        animator.OnAnimationEndEvent -= HandleAnimationEnd;
    }

    public void HandleDestroy()
    {
        Destroy(brain.gameObject);
    }
}
