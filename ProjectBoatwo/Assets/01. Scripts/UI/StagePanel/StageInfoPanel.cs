using UnityEngine;
using UnityEngine.SceneManagement;

public class StageInfoPanel : MonoBehaviour
{
    private StageSO currentStage = null;

    private void Start()
    {
        Display(false);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Init(StageSO stageData)
    {
        // something;
        currentStage = stageData;
    }

    public void HandleStartStage()
    {
        Debug.Log("Start Stage");
        SceneLoader.LoadSceneAsync("GameScene", () => {
            StageManager.Instance.CreateStage(currentStage);
        });
    }
}
