using TMPro;
using UnityEngine;

public class NoticePanel : MonoBehaviour
{
    [SerializeField] Vector2 padding = new Vector2(10, 10);

	private RectTransform rectTransform = null;
    private RectTransform textRectTransform = null;
    private TMP_Text noticeText = null;

    private void Awake()
    {
        noticeText = transform.Find("Text").GetComponent<TMP_Text>();
        textRectTransform = noticeText.transform as RectTransform;
        rectTransform = transform as RectTransform;
    }

    public void SetText(string text)
    {
        noticeText.text = text;
        rectTransform.sizeDelta = textRectTransform.sizeDelta + padding;
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
