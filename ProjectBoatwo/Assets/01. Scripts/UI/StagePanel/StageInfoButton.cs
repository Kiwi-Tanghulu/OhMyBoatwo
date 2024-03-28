using UnityEngine;

public class StageInfoButton : MonoBehaviour
{
    private StagePoint point = null;

    private StagePanel stagePanel = null;
    private StageInfoPanel infoPanel = null;


    private void Awake()
    {
        stagePanel = transform.parent.GetComponent<StagePanel>();
        infoPanel = DEFINE.MainCanvas.Find("StageInfoPanel").GetComponent<StageInfoPanel>();
    }

	public void Init(StagePoint stagePoint)
    {
        point = stagePoint;
    }

    public void HandleClick()
    {
        point.Focus();
        stagePanel.SetFocusedPoint(point);

        infoPanel.Init(point.StageData);
        infoPanel.Display(true);
    }
}
