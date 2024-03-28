using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static event Action OnStartLoadEvent = null;

	public static void LoadSceneAsync(string sceneName, Action callback = null)
    {
        OnStartLoadEvent?.Invoke();
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);
        oper.completed += (i) => callback?.Invoke();
    }
}
