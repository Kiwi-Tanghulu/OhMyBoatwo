using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoPanel : MonoBehaviour
{
    [SerializeField] OptOption<TweenSO> tweenOption = null;

    private StageSO currentStageData = null;

    private Image stageImage = null;
    private TMP_Text nameText = null;
    private StageStarSlot[] starSlots = null;

    private void Awake()
    {
        stageImage = transform.Find("TopPanel/StageImage").GetComponent<Image>();
        nameText = transform.Find("TopPanel/NameField/StageNameText").GetComponent<TMP_Text>();
        starSlots = transform.Find("StarPanel").GetComponentsInChildren<StageStarSlot>(true);

        tweenOption.PositiveOption.Init(transform);
        tweenOption.NegativeOption.Init(transform);
    }

    private void Start()
    {
        Display(false, true);
    }

    public void Display(bool active, bool immediately = false)
    {
        if(immediately)
        {
            gameObject.SetActive(active);
            return;
        }

        if(active)
        {
            gameObject.SetActive(true);
            tweenOption.GetOption(true).PlayTween();
        }
        else
        {
            tweenOption.GetOption(false).PlayTween(() => {
                gameObject.SetActive(false);
            });
        }
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
        tweenOption.NegativeOption.PlayTween(() => {
            SceneLoader.LoadSceneAsync("GameScene", () => {
                StageManager.Instance.CreateStage(currentStageData);
            });
        });
    }
}
