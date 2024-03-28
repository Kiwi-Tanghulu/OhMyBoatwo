using System;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer = 0;

    public event Action<Skeleton> OnSkeletonDestroyEvent = null;

	public void Init()
    {
        // FitToGround();
    }

    public void FitToGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundLayer))
            transform.position = hit.point;
    }

    private void OnDestroy()
    {
        OnSkeletonDestroyEvent?.Invoke(this);
    }
}
