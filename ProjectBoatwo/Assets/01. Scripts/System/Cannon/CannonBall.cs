using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float deactiveTime;
    private Coroutine deactiveCo;
    private WaitForSeconds wfs;

    private Rigidbody rb;

    private LayerMask targetLayer;

    private void Awake()
    {
        wfs = new WaitForSeconds(deactiveTime);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.forward = rb.velocity.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject);
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
            Debug.Log($"hit cannon : {obj.gameObject.name}");
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactiveCo()
    {
        yield return wfs;

        gameObject.SetActive(false);
    }
}
