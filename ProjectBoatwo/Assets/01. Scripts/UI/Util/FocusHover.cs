using UnityEngine;
using UnityEngine.EventSystems;

public class FocusHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float sizeFactor = 1.25f;
    private RectTransform rectTransform;
    
    private Vector2 FOCUSED_SIZE;
    private Vector2 UNFOCUSED_SIZE;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        UNFOCUSED_SIZE = rectTransform.sizeDelta;
        FOCUSED_SIZE = rectTransform.sizeDelta * sizeFactor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.sizeDelta = FOCUSED_SIZE;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.sizeDelta = UNFOCUSED_SIZE;
    }
}
