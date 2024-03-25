using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    private readonly Vector2 FOCUSED_SIZE = new Vector2(150, 150); 
    private readonly Vector2 UNFOCUSED_SIZE = new Vector2(125, 125); 

    private RectTransform rectTransform = null;
	private Image iconImage = null;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        iconImage = transform.Find("Icon").GetComponent<Image>();
    }

    public void Focus(bool focus)
    {
        if(focus)
            rectTransform.sizeDelta = FOCUSED_SIZE;
        else
            rectTransform.sizeDelta = UNFOCUSED_SIZE;
    }

    public void SetIcon(Sprite icon)
    {
        iconImage.sprite = icon;
    }
}
