using System;
using System.Collections;
using UnityEngine;

public class TClick : MonoBehaviour
{
	public void Click()
    {
        DEFINE.FadeImage.FadeInHorizontal(-1);
        StartCoroutine(DelayCoroutine(1f, () => DEFINE.FadeImage.FadeOutHorizontal(-1)));
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
