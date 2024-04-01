using System;
using UnityEngine;
using UnityEngine.VFX;

public class Skeleton : MonoBehaviour
{
    [Space]
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] VisualEffect spawnEffect;

    public event Action<Skeleton> OnSkeletonDestroyEvent = null;

	public void Init()
    {
        // FitToGround();
    }

    public void FitToGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundLayer))
        {
            transform.position = hit.point;
            VisualEffect effect = Instantiate(spawnEffect, hit.point, Quaternion.identity, Ship.Instance.transform);
            effect.Play();
        }
    }

    private void OnDestroy()
    {
        OnSkeletonDestroyEvent?.Invoke(this);
    }
}
