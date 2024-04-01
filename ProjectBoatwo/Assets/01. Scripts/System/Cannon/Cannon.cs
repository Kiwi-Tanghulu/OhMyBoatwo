using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    [Space]
    [SerializeField] private LayerMask targetLayer;

    [Space]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float firePower;
    [SerializeField] private float fireDelay;
    [SerializeField] private CannonBall cannonBallPrefab;
    private WaitForSeconds wfs;
    private bool canFire;

    public UnityEvent<Transform> OnFire;

    public Transform FirePoint => firePoint;

    protected virtual void Awake()
    {
        canFire = true;
        wfs = new WaitForSeconds(fireDelay);
    }

    public virtual void Fire(Vector3 fireDir)
    {
        if (!canFire) return;

        CannonBall ball = PoolManager.Instance.Pop(cannonBallPrefab.name, firePoint.position) as CannonBall;
        ball.gameObject.SetActive(false);
        ball.transform.position = firePoint.position;
        ball.Fire(fireDir * firePower, targetLayer);
        OnFire?.Invoke(firePoint);
    }

    private IEnumerator FireDelay()
    {
        canFire = false;

        yield return wfs;

        canFire = true;
    }
}
