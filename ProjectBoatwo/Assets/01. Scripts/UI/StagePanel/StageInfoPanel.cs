using UnityEngine;

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
    }

    public void HandleStartStage()
    {
        Debug.Log("Start Stage");
    }
}
