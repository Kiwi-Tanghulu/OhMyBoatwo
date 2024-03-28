using UnityEngine;

public class StageBoard : MonoBehaviour
{
	[SerializeField] UIInputSO input = null;
    
    [Space(15f)]
    [SerializeField] float movementSesitivity = 5f;
    
    [Space(15f)]
    [SerializeField] float scrollSesitivity = 0.05f;
    [SerializeField] Vector2 scrollClamp = new Vector2(10, 100);

    private Transform followTarget = null;
    private Transform shipTransform = null;
    private StageCamera stageCam = null;

    private bool isHold = false;

    private void Awake()
    {
        followTarget = transform.Find("FollowTarget");
        shipTransform = transform.Find("Ship");
        stageCam = transform.Find("StageVCam").GetComponent<StageCamera>();

        InputManager.ChangeInputMap(InputMapType.UI);
        input.OnRightClickEevnt += HandleRightClick;
        input.OnScrollEvent += HandleScroll;
        input.OnEscapeEvent += HandleEscape;
    }

    private void FixedUpdate()
    {
        if(isHold == false)
            return;

        Vector2 delta = input.MouseDelta;
        Vector3 factor = new Vector3(-delta.x, 0, -delta.y) * movementSesitivity;
        followTarget.position += factor * Time.fixedDeltaTime;
    }

    private void OnDestroy()
    {
        input.OnRightClickEevnt -= HandleRightClick;
        input.OnScrollEvent -= HandleScroll;
        input.OnEscapeEvent -= HandleEscape;
    }

    private void HandleRightClick(bool click)
    {
        isHold = click;
    }

    private void HandleScroll(float delta)
    {
        float distance = stageCam.Distance;
        distance += -delta * scrollSesitivity;
        stageCam.SetDistance(Mathf.Clamp(distance, scrollClamp.x, scrollClamp.y), 0f);
    }

    private void HandleEscape()
    {
        // followTarget.position = shipTransform.position;
        // stageCam.ResetFollowTarget();
        // stageCam.ResetDistance();
    }
}
