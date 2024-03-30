using System;
using UnityEngine;
using UnityEngine.UI;

public class StageProgressPanel : MonoBehaviour
{
	private Slider progressBar = null;
    private StageSO stageData = null;

    private bool updateProgress = false;

    private void Awake()
    {
        progressBar = transform.Find("ProgressBar").GetComponent<Slider>();
    }

    private void Start()
    {
        StageManager.Instance.OnStageChangedEvent += HandleStageChanged;
        GameManager.Instance.OnGameStateChangedEvent += HandleGameStateChanged;
    }

    private void Update()
    {
        if(updateProgress == false)
            return;

        SetProgress(stageData.PlayingTime / stageData.PlayTime);
    }

    public void SetProgress(float ratio)
    {
        progressBar.value = ratio;
    }

    private void HandleStageChanged(StageSO stageData)
    {
        this.stageData = stageData;
    }

    private void HandleGameStateChanged(GameState state)
    {
        updateProgress = state == GameState.Playing;
    }
}
