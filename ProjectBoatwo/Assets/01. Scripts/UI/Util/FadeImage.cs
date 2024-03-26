using UnityEngine;
using DG.Tweening;

public class FadeImage : MonoBehaviour
{
    [SerializeField] Ease ease = Ease.OutSine;
    private const float HORIZONTAL_SIZE = 2000f;
    private const float VERTICAL_SIZE = 1100f;

	public void FadeInHorizontal(int direction, float duration = 1f)
    {
        transform.localPosition = new Vector3(-direction * HORIZONTAL_SIZE, 0f, 0f);
        transform.DOLocalMoveX(0f, duration).SetEase(ease);
    }

    public void FadeOutHorizontal(int direction, float duration = 1f)
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.DOLocalMoveX(direction * HORIZONTAL_SIZE, duration).SetEase(ease);
    }

	public void FadeInVertical(int direction, float duration = 1f)
    {
        transform.localPosition = new Vector3(0f, -direction * VERTICAL_SIZE, 0f);
        transform.DOLocalMoveY(0f, duration).SetEase(ease);
    }

    public void FadeOutVertical(int direction, float duration = 1f)
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.DOLocalMoveY(direction * VERTICAL_SIZE, duration).SetEase(ease);
    }
}
