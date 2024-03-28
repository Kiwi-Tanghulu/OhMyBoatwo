using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/UIInputSO")]
public class UIInputSO : InputSO, IUIActions
{
    public Action OnEscapeEvent = null;
    public Action<bool> OnLeftClickEevnt = null;
    public Action<bool> OnRightClickEevnt = null;
    public Action<float> OnScrollEvent = null;

    public Vector2 MouseDelta { get; private set; }

    protected override void OnEnable()
    {
        base.OnEnable();
        UIActions play = InputManager.controls.UI;
        play.SetCallbacks(this);
        InputManager.RegistInputMap(this, play.Get());
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnEscapeEvent?.Invoke();
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnScrollEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if(context.performed)
           OnLeftClickEevnt?.Invoke(true);
        else if(context.canceled)
           OnLeftClickEevnt?.Invoke(false);
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnRightClickEevnt?.Invoke(true);
        else if (context.canceled)
            OnRightClickEevnt?.Invoke(false);
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }
}
