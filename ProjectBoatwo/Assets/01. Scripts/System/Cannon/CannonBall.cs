using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public enum CannonBallOwnerType
{
    Player,
    Monster,
}


public class CannonBall : PoolableMono
{
    [SerializeField] private AudioLibrarySO audioClips;

    [Space]
    [SerializeField] private float deactiveTime;
    [SerializeField] private float hitDamage;
    private Coroutine deactiveCo;
    private WaitForSeconds wfs;

    private Rigidbody rb;

    private LayerMask targetLayer;

    public UnityEvent onHit;

    private CannonBallOwnerType ownerType;
    private PlayerHitCrosshair crossHair;

    private void Awake()
    {
        wfs = new WaitForSeconds(deactiveTime);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 dir = rb.velocity.normalized;
        if(dir != Vector3.zero)
            transform.forward = rb.velocity.normalized;

        crossHair = GameObject.FindObjectOfType<PlayerHitCrosshair>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject);
    }

    public void SetOwner(CannonBallOwnerType ownerType)
    {
        this.ownerType = ownerType;
    }

    public void Fire(Vector3 fireVector, LayerMask targetLayer)
    {
        this.targetLayer = targetLayer;
        gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        rb.AddForce(fireVector, ForceMode.Impulse);

        if(deactiveCo != null)
            StopCoroutine(deactiveCo);
        deactiveCo = StartCoroutine(DeactiveCo());
    }

    private void Hit(GameObject obj)
    {
        if (1 << obj.gameObject.layer == targetLayer)
        {
            if (obj.transform.TryGetComponent<IDamageable>(out IDamageable d))
            {
                d.OnDamaged(hitDamage, transform);
                if (ownerType == CannonBallOwnerType.Player)
                {
                    crossHair.SetMaxSize(400f);
                    crossHair.StartCor();
                }
            }

            onHit?.Invoke();
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactiveCo()
    {
        yield return wfs;

        gameObject.SetActive(false);
    }

    public override void Init()
    {
        Debug.Log("pop cannon ball");
    }
}
