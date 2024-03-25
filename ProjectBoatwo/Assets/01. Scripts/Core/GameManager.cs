using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;
    public static GameManager Instance => instance;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
