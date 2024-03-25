using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    //[SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private LayerMask targetLayer;

    [Space]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float firePower;
    [SerializeField] private float fireDelay;
    [SerializeField] private CannonBall cannonBallPrefab;
    private CannonBall cannonBall;
    private WaitForSeconds wfs;
    private bool canFire;

    public UnityEvent<Transform> OnFire;

    private void Awake()
    {
        cannonBall = Instantiate(cannonBallPrefab, transform);
        cannonBall.gameObject.SetActive(false);
        canFire = true;
        wfs = new WaitForSeconds(fireDelay);
    }

    private void Update()
    {
        //inputSO.OnSpaceEvetnt += Fire;
        if (Input.GetKeyDown(KeyCode.O))
            Fire(transform.forward * firePower);
    }

    public void Fire(Vector3 power)
    {
        if (!canFire) return;

        cannonBall.gameObject.SetActive(false);
        cannonBall.transform.position = firePoint.position;
        cannonBall.Fire(power, targetLayer);

        OnFire?.Invoke(firePoint);
    }

    private IEnumerator FireDelay()
    {
        canFire = false;

        yield return wfs;

        canFire = true;
    }
}
