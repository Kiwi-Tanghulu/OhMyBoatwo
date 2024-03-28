using UnityEngine;

public class StageInfoButton : MonoBehaviour
{
    private StagePoint point = null;

    private StagePanel stagePanel = null;


    private void Awake()
    {
        stagePanel = transform.parent.GetComponent<StagePanel>();
    }

	public void Init(StagePoint stagePoint)
    {
        point = stagePoint;
    }

    public void HandleClick()
    {
        point.Focus();
        stagePanel.SetFocusedPoint(point);
    }
}
