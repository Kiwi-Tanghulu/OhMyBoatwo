using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/ShipInputSO")]
public class ShipInputSO : InputSO, IShipActions
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnArrowEvent;
    public event Action<Vector2> OnMouseDeltaEvent;
    public event Action OnFEvent;
    public event Action OnEscapeEvetnt;
    public event Action OnSpaceEvetnt;
    public event Action OnMEvent;
    public event Action OnMouseLeftDownEvent;
     
    protected override void OnEnable()
    {
        base.OnEnable();

        ShipActions ship = InputManager.controls.Ship;
        ship.SetCallbacks(this);
        InputManager.RegistInputMap(this, ship.Get());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnF(InputAction.CallbackContext context)
    {
        if (context.started)
            OnFEvent?.Invoke();
    }

    public void OnArrow(InputAction.CallbackContext context)
    {
        OnArrowEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        OnEscapeEvetnt?.Invoke();
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        OnSpaceEvetnt?.Invoke();
    }

    public void OnM(InputAction.CallbackContext context)
    {
        OnMEvent?.Invoke();
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        OnMouseDeltaEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMouseLeftDown(InputAction.CallbackContext context)
    {
        if (context.started)
            OnMouseLeftDownEvent?.Invoke();
    }
}
