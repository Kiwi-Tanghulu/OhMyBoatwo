using UnityEngine;

public class StagePoint : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0f, 10f, 0f);
    [SerializeField] StageInfoButton infoButtonPrefab = null;
 
    [SerializeField] StageSO stageData = null;
    public StageSO StageData => stageData;

    private StageInfoButton infoButton = null;
	private Transform container = null;

    private StageCamera stageCam = null;
    private Camera mainCamera = null;

    private bool focused = false;
    private float prevDistance = 0f;

    private void Awake()
    {
        container = DEFINE.MainCanvas.Find("StagePanel");
        stageCam = GameObject.Find("StageVCam").GetComponent<StageCamera>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        CreateStageButton();
    }

    private void LateUpdate()
    {
        if(infoButton == null)
            return;

        infoButton.transform.position = mainCamera.WorldToScreenPoint(transform.position) + offset;
    }

    public void Focus()
    {
        focused = true;

        stageCam.SetFollowTarget(transform);
        prevDistance = stageCam.Distance;
        stageCam.SetDistance(10f, 0.5f);
    }

    public void ReleaseFocus()
    {
        focused = false;

        stageCam.ResetFollowTarget();
        stageCam.SetDistance(prevDistance, 0.1f);
    }

    private void CreateStageButton()
    {
        infoButton = Instantiate(infoButtonPrefab, container);
        infoButton.Init(this);
        infoButton.transform.position = mainCamera.WorldToScreenPoint(transform.position) + offset;
    }
}
