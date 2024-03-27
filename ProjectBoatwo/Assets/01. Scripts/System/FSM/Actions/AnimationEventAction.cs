using System;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventAction : FSMAction
{
    public UnityEvent OnAnimationEvent;
    public UnityEvent OnAnimationStartEvent;
    public UnityEvent OnAnimationEndEvent;

    private HumanoidAnimator animator = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        animator = brain.transform.Find("Visual").GetComponent<HumanoidAnimator>();
    }

    public override void EnterState()
    {
        base.EnterState();
        animator.OnAnimationEvent += HandleAnimationEvent;
        animator.OnAnimationStartEvent += HandleAnimationStartEvent;
        animator.OnAnimationEndEvent += HandleAnimationEndEvent;
    }

    public override void ExitState()
    {
        base.EnterState();
        animator.OnAnimationEvent -= HandleAnimationEvent;
        animator.OnAnimationStartEvent -= HandleAnimationStartEvent;
        animator.OnAnimationEndEvent -= HandleAnimationEndEvent;
    }

    private void HandleAnimationEvent()
    {
        OnAnimationEvent?.Invoke();
    }

    private void HandleAnimationStartEvent()
    {
        OnAnimationStartEvent?.Invoke();
    }

    private void HandleAnimationEndEvent()
    {
        OnAnimationEndEvent?.Invoke();
    }
}
