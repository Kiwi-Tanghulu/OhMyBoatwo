using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	private static StageManager instance = null;
    public static StageManager Instance => instance;

    public event Action<StageSO> OnStageChangedEvent = null;

    private Stage currentStage = null;
    public StageSO CurrentStageData => currentStage.StageData;

    private bool isPlaying = false;
    
    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(isPlaying == false)
            return;

        CurrentStageData.PlayingTime += Time.deltaTime;
        if(CurrentStageData.PlayingTime > CurrentStageData.PlayTime)
            FinishStage();
    }

    public void CreateStage(StageSO stageData)
    {
        if(currentStage != null)
            Destroy(currentStage.gameObject);

        currentStage = Instantiate(stageData.StagePrefab);
        currentStage?.InitStage();

        GameManager.Instance.ChangeGameState(GameState.Ready);
        OnStageChangedEvent?.Invoke(currentStage.StageData);
    }

    public void StartStage()
    {
        isPlaying = true;
        GameManager.Instance.ChangeGameState(GameState.Playing);
        currentStage?.StartStage();
    }

    public void FinishStage()
    {
        bool clear = CurrentStageData.PlayingTime > CurrentStageData.PlayTime;
        CurrentStageData.EarnedStar = clear ? 3 : 0;

        GameManager.Instance.ChangeGameState(GameState.Finish);
        currentStage?.FinishStage();
        isPlaying = false;
    }

    public void ReleaseStage()
    {
        Destroy(currentStage.gameObject);
        currentStage = null;
    }
}
