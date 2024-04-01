using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoPanel : MonoBehaviour
{
    [SerializeField] TweenOptOption tweenOption = null;

    private StageSO currentStageData = null;

    private Image stageImage = null;
    private TMP_Text nameText = null;
    private StageStarSlot[] starSlots = null;

    private void Awake()
    {
        stageImage = transform.Find("TopPanel/StageImage").GetComponent<Image>();
        nameText = transform.Find("TopPanel/NameField/StageNameText").GetComponent<TMP_Text>();
        starSlots = transform.Find("StarPanel").GetComponentsInChildren<StageStarSlot>(true);

        tweenOption.Init(transform);
    }

    public void Display(bool active)
    {
        tweenOption.GetOption(active).PlayTween();
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
        Debug.Log("Create Stage");
        tweenOption.NegativeOption.PlayTween(() => {
            DEFINE.FadeImage.FadeInHorizontal(-1, 1f, () => {
                SceneLoader.LoadSceneAsync("GameScene", true, () => {
                    StageManager.Instance.CreateStage(currentStageData);
                    DEFINE.FadeImage.FadeOutHorizontal(1);
                });
            });
        });
    }
}
