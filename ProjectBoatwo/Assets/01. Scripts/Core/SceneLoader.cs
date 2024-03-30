using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static event Action OnStartLoadEvent = null;

	public static void LoadSceneAsync(string sceneName, bool postponeOneFrame, Action callback = null)
    {
        OnStartLoadEvent?.Invoke();
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);
        GameManager.Instance.StartCoroutine(WaitSceneLoadCoroutine(oper, postponeOneFrame, callback));
    }

    private static IEnumerator WaitSceneLoadCoroutine(AsyncOperation oper, bool postponeOneFrame, Action callback)
    {
        yield return oper;
        if(postponeOneFrame)
            yield return null;

        callback?.Invoke();
    }
}
