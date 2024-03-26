using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationTriggerAction : FSMAction
{
    [SerializeField] private FSMState nextState;
    private AnimationTrigger animationTrigger;
    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        animationTrigger = brain.transform.Find("Visual").GetComponent<AnimationTrigger>();
    }

    public override void EnterState()
    {
        base.EnterState();
        animationTrigger.AnimationEnd += ChangeNextState;
    }

    private void ChangeNextState()
    {
        brain.ChangeState(nextState);
    }

    public override void ExitState()
    {
        base.ExitState();
        animationTrigger.AnimationEnd -= ChangeNextState;
    }
}
