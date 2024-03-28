using UnityEngine;

public class StageManager : MonoBehaviour
{
	private static StageManager instance = null;
    public static StageManager Instance => instance;

    private Stage currentStage = null;
    private float timer = 0f;
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

        timer += Time.deltaTime;
        if(timer > currentStage.StageData.PlayTime)
            FinishStage();
    }

    public void CreateStage(StageSO stageData)
    {
        if(currentStage != null)
            Destroy(currentStage.gameObject);

        currentStage = Instantiate(stageData.StagePrefab);
        currentStage?.InitStage();
    }

    public void StartStage()
    {
        isPlaying = true;
        currentStage?.StartStage();
    }

    public void FinishStage()
    {
        currentStage?.FinishStage();
        isPlaying = false;
    }

    public void ReleaseStage()
    {
        Destroy(currentStage.gameObject);
        currentStage = null;
    }
}
