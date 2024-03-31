using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpAction : FSMAction
{
    [SerializeField] private float jumpPower;

    private PlayerMovement playerMovement;
    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        playerMovement = brain.transform.GetComponent<PlayerMovement>();
    }
    public override void EnterState()
    {
        base.EnterState();
        //playerMovement.Rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerMovement.SetVerticalVelocity(jumpPower);
        playerMovement.IsJump = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        playerMovement.Gravity();
    }

    public override void ExitState()
    {
        base.ExitState();
        playerMovement.IsJump = false;
    }

}
