using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
	[SerializeField] StageSO stageData;
    public StageSO StageData => stageData;

    public UnityEvent OnStageInitEvent = null;
    public UnityEvent OnStageStartEvent = null;
    public UnityEvent OnStageFinishEvent = null;
    public UnityEvent OnStageReleaseEvent = null;

    /// <summary>
    /// Should Called by Stage Manager
    /// </summary>
    public void InitStage()
    {
        // 스테이지 초기화
        stageData.PlayingTime = 0f;
        OnStageInitEvent?.Invoke();
    }

    /// <summary>
    /// Should Called by Stage Manager
    /// </summary>
    public void StartStage()
    {
        // 몬스터 사이클을 키는 등
        // 사이클을 시작
        OnStageStartEvent?.Invoke();
    }

    /// <summary>
    /// Should Called by Stage Manager
    /// </summary>
    public void FinishStage()
    {
        // 스테이지가 끝났을 때의 처리를 하면 됨
        OnStageFinishEvent?.Invoke();
        DEFINE.FadeImage.FadeInAlpha(1f, () => {
            SceneLoader.LoadSceneAsync("ResultScene", true, () => {
                ResultPanel resultPanel = DEFINE.MainCanvas.Find("ResultPanel").GetComponent<ResultPanel>();
                resultPanel.Init(stageData.EarnedStar > 0, new PlayerInfo());
                resultPanel.Display(true);
            });
        });
    }

    /// <summary>
    /// Should Called by Stage Manager
    /// </summary>
    public void ReleaseStage()
    {
        OnStageReleaseEvent?.Invoke();
    }
}
