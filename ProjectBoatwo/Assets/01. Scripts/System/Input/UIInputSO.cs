using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/UIInputSO")]
public class UIInputSO : InputSO, IUIActions
{
    public Action OnEscapeEvent = null;
    public Action<float> OnScrollEvent = null;

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
}
