using System;
using UnityEngine;

public class StagePanel : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;
    private StagePoint focusedPoint = null;

    private void Awake()
    {
        input.OnEscapeEvent += HandleEscape;
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetFocusedPoint(StagePoint point)
    {
        focusedPoint = point;
    }

    private void HandleEscape()
    {
        if(focusedPoint == null)
            return;
        
        focusedPoint.ReleaseFocus();
        focusedPoint = null;
    }
}
