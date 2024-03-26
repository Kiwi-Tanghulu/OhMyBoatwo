using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorAction : FSMAction
{
    [SerializeField] private string animBoolName;
    private int animBoolHash;
    private int speedHash = Animator.StringToHash("MoveSpeed");
    private Animator animator;
    private PlayerMovement playerMovement;
    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        animator = brain.transform.Find("Visual").GetComponent<Animator>();
        animBoolHash = Animator.StringToHash(animBoolName);
        playerMovement = brain.transform.GetComponent<PlayerMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();
        animator.SetBool(animBoolHash, true);
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        animator.SetFloat(speedHash, playerMovement.CurrentSpeed);
        Debug.Log(animator.GetBool(animBoolHash));
    }

    public override void ExitState()
    {
        base.ExitState();
        animator.SetBool(animBoolHash, false);
    }
}
