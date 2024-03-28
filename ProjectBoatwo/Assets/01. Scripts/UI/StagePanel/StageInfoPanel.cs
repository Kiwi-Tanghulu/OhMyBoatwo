using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoPanel : MonoBehaviour
{
    private StageSO currentStageData = null;

    private Image stageImage = null;
    private TMP_Text nameText = null;
    private StageStarSlot[] starSlots = null;

    private void Awake()
    {
        stageImage = transform.Find("TopPanel/StageImage").GetComponent<Image>();
        nameText = transform.Find("TopPanel/NameField/StageNameText").GetComponent<TMP_Text>();
        starSlots = transform.Find("StarPanel").GetComponentsInChildren<StageStarSlot>();
    }

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
        currentStageData = stageData;
        
        stageImage.sprite = currentStageData.StageImage;
        nameText.text = stageData.StageName;

        for(int i = 0; i < 3; ++i)
            starSlots[i].Display(i < currentStageData.EarnedStar);
    }

    public void HandleStartStage()
    {
        Debug.Log("Start Stage");
        SceneLoader.LoadSceneAsync("GameScene", () => {
            StageManager.Instance.CreateStage(currentStageData);
        });
    }
}
