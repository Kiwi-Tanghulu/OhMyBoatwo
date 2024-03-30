using UnityEngine;
using UnityEngine.EventSystems;

public class FocusHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TweenOptOption tweenOption = null;

    private void Awake()
    {
        tweenOption.Init(transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(tweenOption.NegativeOption.IsTweening)
            tweenOption.NegativeOption.ForceKillTween();
        tweenOption.PositiveOption.PlayTween();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tweenOption.PositiveOption.IsTweening)
            tweenOption.PositiveOption.ForceKillTween();
        tweenOption.NegativeOption.PlayTween();
    }
}
