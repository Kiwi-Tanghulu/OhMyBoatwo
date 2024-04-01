using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [SerializeField] Ease ease = Ease.OutSine;

    private const float HORIZONTAL_SIZE = 2000f;
    private const float VERTICAL_SIZE = 1100f;

    private Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void FadeInAlpha(float duration = 1f, Action callback = null)
    {
        transform.localPosition = Vector3.zero;
        Color color = image.color;
        color.a = 0f;
        image.color = color;
        image.DOFade(1f, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }

    public void FadeOutAlpha(float duration = 1f, Action callback = null)
    {
        transform.localPosition = Vector3.zero;
        Color color = image.color;
        color.a = 1f;
        image.color = color;
        image.DOFade(0f, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
            transform.localPosition = new Vector3(HORIZONTAL_SIZE, 0, 0);
        });
    }

	public void FadeInHorizontal(int direction, float duration = 1f, Action callback = null)
    {
        transform.localPosition = new Vector3(-direction * HORIZONTAL_SIZE, 0f, 0f);
        transform.DOLocalMoveX(0f, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }

    public void FadeOutHorizontal(int direction, float duration = 1f, Action callback = null)
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.DOLocalMoveX(direction * HORIZONTAL_SIZE, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }

	public void FadeInVertical(int direction, float duration = 1f, Action callback = null)
    {
        transform.localPosition = new Vector3(0f, -direction * VERTICAL_SIZE, 0f);
        transform.DOLocalMoveY(0f, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }

    public void FadeOutVertical(int direction, float duration = 1f, Action callback = null)
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.DOLocalMoveY(direction * VERTICAL_SIZE, duration).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }
}
