using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtensions
{
	public static IEnumerator DelayCoroutine(this MonoBehaviour left, float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
