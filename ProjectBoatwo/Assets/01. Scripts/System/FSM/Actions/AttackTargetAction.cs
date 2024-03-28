using System;
using UnityEngine;

public class AttackTargetAction : FSMAction
{
	[SerializeField] DetectTargetParams targetParam = null;
	[SerializeField] AttackTargetParams attackParam = null;

    private HumanoidAnimator animator = null;
    private NavMovement movement = null;

    private Vector3 attackPosition = Vector3.zero;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        animator = brain.transform.Find("Visual").GetComponent<HumanoidAnimator>();
        movement = brain.GetComponent<NavMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();

        animator.OnAnimationEvent += HandleAnimationEvent;
        animator.OnAnimationEndEvent += HandleAnimationEndEvent;
    
        movement.ActiveAutoRotation(false);

        StartCoroutine(this.DelayCoroutine(attackParam.AttackCooldown * 0.3f, ResetCooldown));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(attackParam.IsCooldown)
            return;

        brain.transform.LookAt(targetParam.Target);
        
        attackParam.IsCooldown = true;
        animator.ToggleAttack(true);

        attackPosition = transform.position;
        movement.SetDestination(attackPosition + transform.forward * attackParam.DashDistance);
    }

    public override void ExitState()
    {
        base.ExitState();
        animator.OnAnimationEvent -= HandleAnimationEvent;
        animator.OnAnimationEndEvent -= HandleAnimationEndEvent;
     
        animator.ToggleAttack(false);
        movement.ActiveAutoRotation(true);

        StopAllCoroutines();
    }

    private void ResetCooldown()
    {
        attackParam.IsCooldown = false;
    }
    
    private void HandleAnimationEvent()
    {
        // attack logic
        Debug.Log("Attack");
        StartCoroutine(this.DelayCoroutine(attackParam.AttackCooldown, ResetCooldown));
        movement.SetDestination(attackPosition);
    }

    private void HandleAnimationEndEvent()
    {
        animator.ToggleAttack(false);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(attackParam == null)
            return;
        
        attackParam.DrawGizmo(transform);
    }
    #endif
}
