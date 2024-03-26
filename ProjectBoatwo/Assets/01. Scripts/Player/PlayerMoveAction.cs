using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveAction : FSMAction
{
    [SerializeField] private FSMState nextState;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private PlayerMovement playerMovement;
    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        playerMovement = brain.transform.GetComponent<PlayerMovement>();
    }
    public override void EnterState()
    {
        base.EnterState();
        playerMovement.Input.OnRunEvent += SetRun;
        playerMovement.Input.OnJumpEvent += SetJump;
        SetRun(playerMovement.IsRun);
    }
    public override void ExitState()
    {
        base.ExitState();
        playerMovement.Input.OnRunEvent -= SetRun;
        playerMovement.Input.OnJumpEvent -= SetJump;
    }

    private void SetJump()
    {
        brain.ChangeState(nextState);
    }
    
    private void SetRun(bool isRun)
    {
        playerMovement.IsRun = isRun;
        float speed = playerMovement.IsRun ? maxSpeed : minSpeed;
        playerMovement.SetCurrentMaxSpeed(speed);
    }
}
