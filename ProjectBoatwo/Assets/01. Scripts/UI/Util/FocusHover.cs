using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FocusHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TweenOptOption tweenOption = null;
    public UnityEvent OnHoverEnterEvent = null;
    public UnityEvent OnHoverExitEvent = null;

    private void Awake()
    {
        tweenOption.Init(transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(tweenOption.NegativeOption.IsTweening)
            tweenOption.NegativeOption.ForceKillTween();
        tweenOption.PositiveOption.PlayTween();
        OnHoverEnterEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tweenOption.PositiveOption.IsTweening)
            tweenOption.PositiveOption.ForceKillTween();
        tweenOption.NegativeOption.PlayTween();
        OnHoverExitEvent?.Invoke();
    }
}
