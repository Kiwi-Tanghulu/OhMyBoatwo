using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitCrosshair : MonoBehaviour
{
    [SerializeField] private Color32 minColor;
    [SerializeField] private Color32 maxColor;

    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private List<Image> linesImage;
    private float currentValue;
    [SerializeField] private float duration;
    private RectTransform crosshairRect;

    private void Awake()
    {
        crosshairRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        for (int i = 0; i < linesImage.Count; i++)
        {
            linesImage[i].color = maxColor;
        }
    }

    private IEnumerator CrosshairDynamic()
    {
        float time = 0f;
        while (time <= duration)
        {
            float t = time / duration;
            for(int i = 0; i < linesImage.Count; i++) 
            {
                linesImage[i].color = Color32.Lerp(minColor, maxColor, t);
            }
            currentValue = Mathf.Lerp(minSize, maxSize, t);
            crosshairRect.sizeDelta = new Vector2(currentValue, currentValue);
            time += Time.deltaTime;
            yield return null;
        }
        crosshairRect.sizeDelta = new Vector2(maxSize, maxSize);
    }
}
