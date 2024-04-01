using System.Collections;
using System.Linq.Expressions;
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

    private void Start()
    {
        Display(false);
    }

    public void SetText(string text)
    {
        Display(true);
        StopAllCoroutines();
        noticeText.text = text;
        rectTransform.sizeDelta = textRectTransform.sizeDelta + padding;
        StartCoroutine(DisplayCo());
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private IEnumerator DisplayCo()
    {
        Display(true);

        yield return new WaitForSeconds(5f);

        Display(false);
    }
}
