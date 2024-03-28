using UnityEngine;

public class HitAction : FSMAction
{
    private NavMovement movement = null;
    private float originSpeed = 0f;
    private float originAccel = 0f;
    
    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        movement = brain.GetComponent<NavMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();

        originSpeed = movement.Speed;
        originAccel = movement.Accel;
        
        movement.Speed = 7.5f;
        movement.Accel = 50f;
        
        movement.ActiveAutoRotation(false);
        movement.SetDestination(transform.position - transform.forward * 0.5f);
    }

    public override void ExitState()
    {
        base.ExitState();

        movement.Speed = originSpeed;
        movement.Accel = originAccel;
        movement.ActiveAutoRotation(false);
    }
}
