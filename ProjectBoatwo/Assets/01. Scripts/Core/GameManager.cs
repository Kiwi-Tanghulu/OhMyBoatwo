using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;
    public static GameManager Instance => instance;

    private GameState gameState = GameState.None;
	public event Action<GameState> OnGameStateChangedEvent = null;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
        OnGameStateChangedEvent?.Invoke(gameState);
    }
}
