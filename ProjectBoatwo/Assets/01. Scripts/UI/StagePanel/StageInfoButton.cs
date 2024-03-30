using System.Collections;
using UnityEngine;

public class StageInfoButton : MonoBehaviour
{
    private StagePoint point = null;

    private StagePanel stagePanel = null;
    private StageInfoPanel infoPanel = null;

    private CanvasGroup canvasGroup = null;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        stagePanel = transform.parent.GetComponent<StagePanel>();
        infoPanel = DEFINE.MainCanvas.Find("StageInfoPanel").GetComponent<StageInfoPanel>();
    }

	public void Init(StagePoint stagePoint)
    {
        point = stagePoint;
    }

    public void HandleClick()
    {
        point.Focus();
        stagePanel.SetFocusedPoint(point);

        infoPanel.Init(point.StageData);
        infoPanel.Display(true);
    }

    public void SetOpacity(float opacity)
    {
        StopAllCoroutines();
        StartCoroutine(SetOpacityCoroutine(opacity, 0.2f));
    }

    private IEnumerator SetOpacityCoroutine(float endValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float timer = 0f;
        float theta = 0f;

        while(theta < 1f)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, endValue, theta);
            timer += Time.deltaTime;
            theta = timer / duration;
            yield return null;
        }

        canvasGroup.alpha = endValue;
    }
}
