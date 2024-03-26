using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFocuser : MonoBehaviour
{
    [SerializeField] Transform eyeTranform = null;
    [SerializeField] LayerMask focusingLayer = 0;
    [SerializeField] float distance = 0.5f;

    private IFocusable focusedObject = null;
    public IFocusable FocusedObject => focusedObject;

    public bool IsEmpty => focusedObject == null;

    public Vector3 FocusedPoint = Vector3.zero;

    private void Awake()
    {
        eyeTranform = Camera.main.transform;
    }

    private void Update()
    {
        IFocusable other = null;
        Vector3 point = eyeTranform.position + eyeTranform.forward * distance;

        bool rayResult = Physics.Raycast(eyeTranform.position, eyeTranform.forward, out RaycastHit hit, distance, focusingLayer);
        if (rayResult)
        {
            hit.collider.TryGetComponent<IFocusable>(out other);
            point = hit.point;
        }

        if (focusedObject != other)
            FocusObject(other, point);

        FocusedPoint = point;
    }

    private void FocusObject(IFocusable other, Vector3 point)
    {
        focusedObject?.OnFocusEnd();
        focusedObject = other;
        focusedObject?.OnFocusBegin(point);
    }

#if UNITY_EDITOR
    [Space(15f)]
    [SerializeField] bool gizmo = false;

    private void OnDrawGizmos()
    {
        if (gizmo == false)
            return;

        if (eyeTranform == null)
            return;

        Vector3 start = eyeTranform.position;
        Vector3 end = eyeTranform.position + eyeTranform.forward * distance;
        if (Physics.Raycast(eyeTranform.position, eyeTranform.forward, out RaycastHit hit, distance, focusingLayer))
            end = hit.point;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawWireSphere(end, 0.05f);
    }
#endif
}
