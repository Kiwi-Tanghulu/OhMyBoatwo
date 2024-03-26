using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/PlayInputSO")]
public class PlayInputSO : InputSO, IPlayActions
{
    public Action<Vector2> OnMoveEvent;
    public Action<Vector2> OnMouseDeltaEvent;
    public Action<float> OnMouseWheelEvent;
    public Action OnJumpEvent;
    public Action OnCollectEvent;
    public Action<bool> OnInteractEvent;
    public Action OnFireEvent;
    public Action <bool>OnRunEvent;

    protected override void OnEnable()
    {
        base.OnEnable();

        PlayActions play = InputManager.controls.Play;
        play.SetCallbacks(this);
        InputManager.RegistInputMap(this, play.Get());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(moveDirection);
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();

        OnMouseDeltaEvent?.Invoke(mouseDelta);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnCollect(InputAction.CallbackContext context)
    {
        if(context.started)
            OnCollectEvent?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
            OnInteractEvent?.Invoke(true);
        else if(context.canceled)
            OnInteractEvent?.Invoke(false);
    }

    public void OnMouseWheel(InputAction.CallbackContext context)
    {
        OnMouseWheelEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.started)
            OnFireEvent?.Invoke();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
            OnRunEvent?.Invoke(true);
        else if (context.canceled)
            OnRunEvent?.Invoke(false);
    }
}
